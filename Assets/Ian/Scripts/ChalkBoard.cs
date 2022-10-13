using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChalkBoard : MonoBehaviour
{
    #region wipe board
    public Sprite transparentSprite;
    public GameObject wipe;
    public float wipeRadius;

    public List<string> currentKeys;
    #endregion

    public List<Vector2> dirs;
    private float distCounter;
    private Vector2 prevMousePos;
    private Vector2 prevPoint;

    // Start is called before the first frame update
    void Start()
    {
        // set the masksprite texture to be totally white&transparent
        //Texture2D tex = new Texture2D(transparentSprite.width, transparentSprite.height);

        //Sprite newSprite = Sprite.Create(transparentSprite, new Rect(0, 0, transparentSprite.width, transparentSprite.height), new Vector2(transparentSprite.width / 2f, transparentSprite.height / 2f));
        //maskSpriteMask.sprite = newSprite;
        //maskSR.sprite = newSprite;

        Color[] colors = new Color[transparentSprite.texture.width * transparentSprite.texture.height];
        for (int i=0; i<colors.Length; i++)
        {
            colors[i] = new Color(1f, 1f, 1f, 0f);
        }
        transparentSprite.texture.SetPixels(colors);
        transparentSprite.texture.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        #region wipe board
        // update the input list
        string inputString = Input.inputString;
        if (inputString.Length > 0)
        {
            foreach (char c in inputString)
            {
                string s = c.ToString().ToLower();
                if (!currentKeys.Contains(s) && !s.Equals(" ") && !s.Equals("\n"))
                {
                    currentKeys.Add(s);
                }
            }
        }
        for(int i=currentKeys.Count-1; i>=0; i--)
        {
            string key = currentKeys[i];
            if (Input.GetKeyUp(key))
            {
                currentKeys.RemoveAt(i);
            }
        }


        // get an average position and update the invisible ball's position, then update the pixels on the mask
        if (currentKeys.Count > 0)
        {
            Vector2 avg = Vector2.zero;
            int count = 0;
            foreach (string s in currentKeys)
            {
                Vector2 pos = getKeyPos(s);
                avg.x += pos.x;
                avg.y += pos.y;
                count++;
            }
            avg.x = avg.x / count;
            avg.y = avg.y / count;

            Debug.Log(avg);

            if (wipe.activeSelf == false)
            {
                wipe.SetActive(true);
                wipe.transform.position = avg;
            }
            else
            {
                Vector3 force = new Vector3(avg.x - wipe.transform.position.x, avg.y - wipe.transform.position.y).normalized;
                Rigidbody rb = wipe.GetComponent<Rigidbody>();
                rb.AddForce(force * 50f);
                if (rb.velocity.magnitude > 5f)
                {
                    rb.velocity = rb.velocity.normalized * 5f;
                }
            }


            // use the ball position to update the pixels on the sprite
            float xScale = 100f / 13f;
            float yScale = 50f / 3f;

            Vector2Int pixelCenter = Vector2Int.zero;
            pixelCenter.x = (int)(wipe.transform.position.x * xScale);
            pixelCenter.y = (int)((wipe.transform.position.y-1) * yScale);

            float radius = currentKeys.Count - 1;//Mathf.Sqrt(currentKeys.Count - 1);


            Sprite maskSprite = transparentSprite;
            Color[] colors = maskSprite.texture.GetPixels();
            for (int i=0; i<maskSprite.texture.width; i++)
            {
                for (int j=0; j<maskSprite.texture.height; j++)
                {
                    if (Vector2.Distance(pixelCenter, new Vector2(i, j)) < wipeRadius * radius)
                    {
                        colors[j * maskSprite.texture.width + i] = Color.black;
                    }
                }
            }
            maskSprite.texture.SetPixels(colors);
            maskSprite.texture.Apply();
        }
        else
        {
            wipe.GetComponent<Rigidbody>().velocity = Vector3.zero;
            wipe.SetActive(false);
        }
        #endregion

        if (Input.GetMouseButtonDown(0))
        {
            prevPoint = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            //Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Vector2 mousePos = Input.mousePosition;
            //Debug.Log(mousePos);
            if (prevMousePos != Vector2.zero)
            {
                distCounter += Vector2.Distance(mousePos, prevMousePos);
            }

            if (distCounter > 50f)
            {
                distCounter = 0f;
                Vector2 thisDir = mousePos - prevPoint;

                // if first dir, need to be pointing bottom right
                if (dirs.Count == 0)
                {
                    if (thisDir.x > 0 && thisDir.y < 0)
                    {
                        dirs.Add(thisDir);
                    }
                }
                // if not, add to the list if within an angle
                //                          else, make it the first one of the list if its pointing bottom right, if not, clear list
                else
                {
                    float angle = Vector2.SignedAngle(dirs[dirs.Count - 1], thisDir);
                    if (angle < 60f && angle > 0f)
                    {
                        dirs.Add(thisDir);
                    }
                    else
                    {
                        dirs.Clear();
                        if (thisDir.x > 0 && thisDir.y < 0)
                        {
                            dirs.Add(thisDir);
                        }
                    }
                }
                prevPoint = mousePos;


                if (dirs.Count > 4 && dirs[dirs.Count-1].x > 0 && dirs[dirs.Count - 1].y > 0 && (dirs[dirs.Count-1].y - dirs[0].y) > -15f)
                {
                    Debug.Log("circle!");
                    dirs.Clear();
                }
            }


            prevMousePos = mousePos;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            dirs.Clear();
            distCounter = 0;
            prevMousePos = Vector2.zero;
        }
    }

    private Vector2 getKeyPos(string key)
    {
        Vector2 pos = Vector2.zero;
        switch (key)
        {
            case "`":
                pos.x = 0;
                pos.y = 4;
                break;
            case "~":
                pos.x = 0;
                pos.y = 4;
                break;
            case "1":
                pos.x = 1;
                pos.y = 4;
                break;
            case "!":
                pos.x = 1;
                pos.y = 4;
                break;
            case "2":
                pos.x = 2;
                pos.y = 4;
                break;
            case "@":
                pos.x = 2;
                pos.y = 4;
                break;
            case "3":
                pos.x = 3;
                pos.y = 4;
                break;
            case "#":
                pos.x = 3;
                pos.y = 4;
                break;
            case "4":
                pos.x = 4;
                pos.y = 4;
                break;
            case "$":
                pos.x = 4;
                pos.y = 4;
                break;
            case "5":
                pos.x = 5;
                pos.y = 4;
                break;
            case "%":
                pos.x = 5;
                pos.y = 4;
                break;
            case "6":
                pos.x = 6;
                pos.y = 4;
                break;
            case "^":
                pos.x = 6;
                pos.y = 4;
                break;
            case "7":
                pos.x = 7;
                pos.y = 4;
                break;
            case "&":
                pos.x = 7;
                pos.y = 4;
                break;
            case "8":
                pos.x = 8;
                pos.y = 4;
                break;
            case "*":
                pos.x = 8;
                pos.y = 4;
                break;
            case "9":
                pos.x = 9;
                pos.y = 4;
                break;
            case "(":
                pos.x = 9;
                pos.y = 4;
                break;
            case "0":
                pos.x = 10;
                pos.y = 4;
                break;
            case ")":
                pos.x = 10;
                pos.y = 4;
                break;
            case "-":
                pos.x = 11;
                pos.y = 4;
                break;
            case "_":
                pos.x = 11;
                pos.y = 4;
                break;
            case "=":
                pos.x = 12;
                pos.y = 4;
                break;
            case "+":
                pos.x = 12;
                pos.y = 4;
                break;
            case "q":
                pos.x = 1.4f;
                pos.y = 3;
                break;
            case "Q":
                pos.x = 1.4f;
                pos.y = 3;
                break;
            case "w":
                pos.x = 2.4f;
                pos.y = 3;
                break;
            case "W":
                pos.x = 2.4f;
                pos.y = 3;
                break;
            case "e":
                pos.x = 3.4f;
                pos.y = 3;
                break;
            case "E":
                pos.x = 3.4f;
                pos.y = 3;
                break;
            case "r":
                pos.x = 4.4f;
                pos.y = 3;
                break;
            case "R":
                pos.x = 4.4f;
                pos.y = 3;
                break;
            case "t":
                pos.x = 5.4f;
                pos.y = 3;
                break;
            case "T":
                pos.x = 5.4f;
                pos.y = 3;
                break;
            case "y":
                pos.x = 6.4f;
                pos.y = 3;
                break;
            case "Y":
                pos.x = 6.4f;
                pos.y = 3;
                break;
            case "u":
                pos.x = 7.4f;
                pos.y = 3;
                break;
            case "U":
                pos.x = 7.4f;
                pos.y = 3;
                break;
            case "i":
                pos.x = 8.4f;
                pos.y = 3;
                break;
            case "I":
                pos.x = 8.4f;
                pos.y = 3;
                break;
            case "o":
                pos.x = 9.4f;
                pos.y = 3;
                break;
            case "O":
                pos.x = 9.4f;
                pos.y = 3;
                break;
            case "p":
                pos.x = 10.4f;
                pos.y = 3;
                break;
            case "P":
                pos.x = 10.4f;
                pos.y = 3;
                break;
            case "[":
                pos.x = 11.4f;
                pos.y = 3;
                break;
            case "{":
                pos.x = 11.4f;
                pos.y = 3;
                break;
            case "]":
                pos.x = 12.4f;
                pos.y = 3;
                break;
            case "}":
                pos.x = 12.4f;
                pos.y = 3;
                break;
            case "\\":
                pos.x = 13.4f;
                pos.y = 3;
                break;
            case "|":
                pos.x = 13.4f;
                pos.y = 3;
                break;
            case "a":
                pos.x = 1.8f;
                pos.y = 2;
                break;
            case "A":
                pos.x = 1.8f;
                pos.y = 2;
                break;
            case "s":
                pos.x = 2.8f;
                pos.y = 2;
                break;
            case "S":
                pos.x = 2.8f;
                pos.y = 2;
                break;
            case "d":
                pos.x = 3.8f;
                pos.y = 2;
                break;
            case "D":
                pos.x = 3.8f;
                pos.y = 2;
                break;
            case "f":
                pos.x = 4.8f;
                pos.y = 2;
                break;
            case "F":
                pos.x = 4.8f;
                pos.y = 2;
                break;
            case "g":
                pos.x = 5.8f;
                pos.y = 2;
                break;
            case "G":
                pos.x = 5.8f;
                pos.y = 2;
                break;
            case "h":
                pos.x = 6.8f;
                pos.y = 2;
                break;
            case "H":
                pos.x = 6.8f;
                pos.y = 2;
                break;
            case "j":
                pos.x = 7.8f;
                pos.y = 2;
                break;
            case "J":
                pos.x = 7.8f;
                pos.y = 2;
                break;
            case "k":
                pos.x = 8.8f;
                pos.y = 2;
                break;
            case "K":
                pos.x = 8.8f;
                pos.y = 2;
                break;
            case "l":
                pos.x = 9.8f;
                pos.y = 2;
                break;
            case "L":
                pos.x = 9.8f;
                pos.y = 2;
                break;
            case ";":
                pos.x = 10.8f;
                pos.y = 2;
                break;
            case ":":
                pos.x = 10.8f;
                pos.y = 2;
                break;
            case "'":
                pos.x = 11.8f;
                pos.y = 2;
                break;
            case "\"":
                pos.x = 11.8f;
                pos.y = 2;
                break;
            case "z":
                pos.x = 2.2f;
                pos.y = 1;
                break;
            case "Z":
                pos.x = 2.2f;
                pos.y = 1;
                break;
            case "x":
                pos.x = 3.2f;
                pos.y = 1;
                break;
            case "X":
                pos.x = 3.2f;
                pos.y = 1;
                break;
            case "c":
                pos.x = 4.2f;
                pos.y = 1;
                break;
            case "C":
                pos.x = 4.2f;
                pos.y = 1;
                break;
            case "v":
                pos.x = 5.2f;
                pos.y = 1;
                break;
            case "V":
                pos.x = 5.2f;
                pos.y = 1;
                break;
            case "b":
                pos.x = 6.2f;
                pos.y = 1;
                break;
            case "B":
                pos.x = 6.2f;
                pos.y = 1;
                break;
            case "n":
                pos.x = 7.2f;
                pos.y = 1;
                break;
            case "N":
                pos.x = 7.2f;
                pos.y = 1;
                break;
            case "m":
                pos.x = 8.2f;
                pos.y = 1;
                break;
            case "M":
                pos.x = 8.2f;
                pos.y = 1;
                break;
            case ",":
                pos.x = 9.2f;
                pos.y = 1;
                break;
            case "<":
                pos.x = 9.2f;
                pos.y = 1;
                break;
            case ".":
                pos.x = 10.2f;
                pos.y = 1;
                break;
            case ">":
                pos.x = 10.2f;
                pos.y = 1;
                break;
            case "/":
                pos.x = 11.2f;
                pos.y = 1;
                break;
            case "?":
                pos.x = 11.2f;
                pos.y = 1;
                break;
            default:
                pos.x = 6f;
                pos.y = 0;
                break;
        }

        return pos;
    }
}
