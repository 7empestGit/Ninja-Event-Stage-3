# CS50x 2021 Final Project. Ismayil Mammadov
## "POTHOLE MADNESS" - 2D RACING GAME
#### Video Demo:  https://youtu.be/7ICdcWpRa00
#### Description:
  Game created using Unity Engine version 2020.3.9f1.
  In this repo you'll find two folders:
  Source Code and Game Build.
  In order to run the game you have to go to **Game Build ---> Open PotholeMadness.exe**
  ##### Controls:
  Use A and D (or left arrow and right arrow keys) to rotate car to the left and right respectively.
  Avoid obstacles, and collect coins. Each coin will give you 100+ in your score.
  On the main screen you can see your best score. Enjoy!

### What I have done so far in this project
  Game has 3 states: MenuState, PlayState, EndState.
  First I started building the PlayState because it is the most important part. The car has a CarController script which is responsible for car actions. For instance, it has an OnTriggerEnter method which detects if the trigger's tag is "Coin" then collect it ---> Meaning that do these steps: 1. Add 100 to the current score. 2. Play an animation. 3. Play a sound. 4. Destroy the coin gameObject. Road is being controlled by a RoadController which uses the technique as in Helicopter Game (scrolling the 2D Texture). One more interesting detail is random generation of obstacles\coins. I simply made a GameController script which has an Update method and uses the code below:
```C#
Timer -= Time.deltaTime;
if (Timer <= 0f)
{
    float x = Random.Range(0, 2);
    x = x == 0 ? -1.3f : 1.3f;
    float y = Random.Range(6f, 9f);
    SpawnObject(x,y);
    Timer = Random.Range(1f, 2f);
}
```
Timer is a public float variable with a start value of 2.0f. So I check when Timer goes below 0, I request a random number between 0 and 1, and use ternary operator (:?) to check for 50% chance and set the offsets (which is -1.3f and 1.3f) (right side or left side of the road) that will be set on the road. Next I also randomize the Y position of the object (to make a more random delay). SpawnObject method has this code:
```C#
void SpawnObject(float x, float y)
    {
        int num = Random.Range(0, 3);
        if (num == 0)
        {
            Instantiate(blocksign, new Vector2(x, y), transform.rotation);
        }
        else if (num == 1)
        {
            Instantiate(pothole, new Vector2(x, y), transform.rotation);
        }
        else
        {
            Instantiate(coin, new Vector2(x, y), transform.rotation);
        }
    }
```
It simply takes a random number between 0 and 3 and Instantiate the object, whether it will be a coin, pothole, or a blocksign.
Now, the skin changer of the car. I used the PlayerPrefs method in order to do this.
This line of code:
```C#
PlayerPrefs.SetInt("selectedSkinID", selectedSkinID);
```
is saving an index of the selected skin. Which is used in GameManager in the Start method:
```C#
int skinID = PlayerPrefs.GetInt("selectedSkinID");
playersprite = skins[skinID];
Player.GetComponent<SpriteRenderer>().sprite = playersprite;
```
Here, on the first line I get the id, on the second line I get the actual sprite from sprite List, and on the third line, I change car's sprite.
