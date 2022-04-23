using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Game : MonoBehaviour
{
    GameObject[] pinObjects;
    GameObject[] iscoreObjs;
    GameObject[] cscoreObjs;

    public TextMeshProUGUI final;
    public TextMeshProUGUI congrats;
    GameObject ballObject;
    int scoreCalculation = 0;
    int finalScoreCalculation = 0;
    public TextMeshProUGUI scoreShowUI;
    public TextMeshProUGUI totalScoreShowUI;
    int countTurns = 0;
    int countFrames=0;
    public Rigidbody rb;
    [SerializeField]
    float power;
    bool ballFlag=true;
    bool frameFlag=true;
    bool scoreFlag=false;
    bool corFlag=true;
    int[] scores=new int[21];
    // string scoreCardString="";
    Dictionary<int,char> intToChar = new Dictionary<int, char>(){
            {0,'0'},{1,'1'},{2,'2'},{3,'3'},{4,'4'},{5,'5'},{6,'6'},{7,'7'},{8,'8'},{9,'9'},{10,'X'}
        };
    Dictionary<int,char> intToChar2 = new Dictionary<int, char>(){
            {0,'0'},{1,'1'},{2,'2'},{3,'3'},{4,'4'},{5,'5'},{6,'6'},{7,'7'},{8,'8'},{9,'9'},{10,'X'}
        };


    int[] totalScoreArr=new int[10];
    char[] finalScore="||       |       |       |       |       |       |       |       |       |       |       ||".ToCharArray();
    char[] scoreCard="||   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   ||".ToCharArray() ;
    Vector3[] pinPositions;
    Vector3 ballPosition;
    
    // Start is called before the first frame update
    void Start(){
        pinObjects = GameObject.FindGameObjectsWithTag("Pins");
        iscoreObjs = GameObject.FindGameObjectsWithTag("iscor");
        cscoreObjs = GameObject.FindGameObjectsWithTag("csore");
        rb =GetComponent<Rigidbody>();
        ballObject=this.gameObject;
        
        // final.text=300.ToString();
        // string finalScoreCardString="300";
        // congrats.text=$"Congrats, Your total score {finalScoreCardString}";

        // Debug.Log(ballObject);
        pinPositions = new Vector3[pinObjects.Length];
        ballPosition = new Vector3();
        int k = 0;
        while (k < pinObjects.Length)
        {
            pinPositions[k] = pinObjects[k].transform.position;
            k++;
        }
        ballObject.GetComponent<Rigidbody>().maxAngularVelocity = (float)(3.5 * ballObject.GetComponent<Rigidbody>().maxAngularVelocity);
        ballPosition = ballObject.transform.position;
        // Debug.Log(ballPosition);
    }


    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Return))
        // {
        //     rb.AddForce(Vector3.forward*power);
        //     AudioSource src1= GetComponent<AudioSource>();
        //     src1.Play();
        // }
    }


    
    void pinsDownCount()
    {
        int k = 0;
        while (k < pinObjects.Length)
        {   //check which pins have fallen
            if ((pinObjects[k].transform.eulerAngles.z < 350 && pinObjects[k].transform.eulerAngles.z > 10 && pinObjects[k].activeSelf)
            ||(pinObjects[k].transform.eulerAngles.x < 350 && pinObjects[k].transform.eulerAngles.x > 10 && pinObjects[k].activeSelf))
            {
                scoreCalculation++;
                pinObjects[k].SetActive(false);
            }
            k++;
        }

        // scoreShowUI.text = scoreCalculation.ToString();
    }
    void resetPinsBalls()
    {
        for (int i = 0; i < pinObjects.Length; i++)
        {   
            
            pinObjects[i].SetActive(true);
            pinObjects[i].transform.position = pinPositions[i];
            pinObjects[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pinObjects[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pinObjects[i].transform.rotation = Quaternion.identity;
            
        }
    ballFlag=true;
            
            // frameFlag=true;

            ballObject.transform.position = ballPosition;
            ballObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ballObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ballObject.transform.rotation = Quaternion.identity;

    }


    //clear frame if first throw is not a strike
    void clearPins()
    {
        for (int i = 0; i < pinObjects.Length; i++)
        {
            if ((pinObjects[i].transform.eulerAngles.z < 350 && pinObjects[i].transform.eulerAngles.z > 10 && pinObjects[i].activeSelf)
            ||(pinObjects[i].transform.eulerAngles.x < 350 && pinObjects[i].transform.eulerAngles.x > 10 && pinObjects[i].activeSelf)){
            Destroy(pinObjects[i]);
            }
        }   
    ballFlag=true;
            
            ballObject.transform.position = ballPosition;
            ballObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ballObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ballObject.transform.rotation = Quaternion.identity;

    }
    private void OnTriggerEnter(Collider enter){
        // Debug.Log(enter.gameObject.name);

        if(enter.gameObject.name=="Plane" || enter.gameObject.name=="Allpin"){
            if(corFlag){
            StartCoroutine(resetWaitCoroutine(9));
            }
        }
        else if(enter.gameObject.name=="DetectThrow"){
            Debug.Log("Ball on lane");
            AudioSource src1 =GetComponent<AudioSource>();
            src1.Play();
        }
        
    }

    IEnumerator resetWaitCoroutine(int time)
    {
        // waits for (time) seconds.
        // Debug.Log("reset invoke pins");
        corFlag=false;
        yield return new WaitForSecondsRealtime(time);
        pinsDownCount();
        if(ballFlag==true)
            {
            countTurns++;
            Debug.Log("Turn "+countTurns);

            ballFlag=false;
            scoreFlag=true;
            if(countTurns%2==0 && countTurns!=20){
                frameFlag=true;
            }
            }
        if(scoreFlag==true){
            
            scores[countTurns-1]=scoreCalculation;

            if(countTurns%2==1 && countTurns<19 ){
                if(scoreCalculation==10){
                Debug.Log("con1");
                scoreCard[4*countTurns-1]='X';
                iscoreObjs[countTurns-1].GetComponent<TextMeshProUGUI>().text="X";

                countTurns++;
                scores[countTurns]=0;
                scoreCard[4*countTurns-1]=' ';

                iscoreObjs[countTurns-1].GetComponent<TextMeshProUGUI>().text=" ";

                frameFlag=true;
                }
                else{
                Debug.Log("con4");

                    scoreCard[4*countTurns-1]=intToChar[scoreCalculation];
                iscoreObjs[countTurns-1].GetComponent<TextMeshProUGUI>().text=(intToChar2[scoreCalculation]).ToString();

                }
            }
            else if(countTurns%2==0 && countTurns<19 ){
                if(scores[countTurns-1]+scores[countTurns-2]==10){
                Debug.Log("con2");

                    scoreCard[4*countTurns-1]='/';
            iscoreObjs[countTurns-1].GetComponent<TextMeshProUGUI>().text="/";

                }
                else{
                Debug.Log("con3");

                    scoreCard[4*countTurns-1]=intToChar[scoreCalculation];
            iscoreObjs[countTurns-1].GetComponent<TextMeshProUGUI>().text=(intToChar2[scoreCalculation]).ToString();

                }
            }
            else if(countTurns>=19){
                if(scoreCalculation==10){
                Debug.Log("con1");
                scoreCard[4*countTurns-1]='X';
                                iscoreObjs[countTurns-1].GetComponent<TextMeshProUGUI>().text="X";

                }
                else{
                    Debug.Log("con6");
                scoreCard[4*countTurns-1]=intToChar[scoreCalculation];
                            iscoreObjs[countTurns-1].GetComponent<TextMeshProUGUI>().text=(intToChar2[scoreCalculation]).ToString();

                }

            }
            string scoreCardString=new string(scoreCard);
            string scoreprint="";
            for(int i=0;i<scoreCard.Length;i++)
            {
                scoreprint+=scoreCard[i];
            }
            Debug.Log(scoreprint);
            Debug.Log("Score String"+scoreCardString);
            scoreShowUI.text=scoreCardString;
                
            scoreFlag=false;
            scoreCalculation=0;

        }
        

        if(countFrames!=9){
            if(countTurns % 2 ==1){
                clearPins();
            }
            else {
                
                if(frameFlag==true){
                resetPinsBalls();           
                countFrames++;
                frameFlag=false;
                Debug.Log("Frames "+countFrames);}
            }
        }
        else{
            if(countTurns==21){
                
                if(frameFlag==true){
                resetPinsBalls();    
                countFrames++;
                frameFlag=false;
                Debug.Log("Frames "+countFrames);
                }
                endGame();
            }
            else{
                if(countTurns==20){
                    if(scores[countTurns-1]+scores[countTurns-2]==10){
                        resetPinsBalls();
                    }
                    else{
                        scores[20]=0;
                        endGame();
                    }
                }
                if(scores[countTurns-1]==10){
                    resetPinsBalls();
                }
                clearPins();

            }

        
        }

    corFlag=true;

    }

    public void endGame(){
        for(int x=0;x<21;x++){
            Debug.Log(scores[x]);
        }
        for(int i=0;i<16;i+=2){
            //strike
            if(scores[i]==10&&i%2==0){
                if(scores[i+2]==10){
                     totalScoreArr[i/2]=20+scores[i+4];
                    
                }
                else{
                totalScoreArr[i/2]=10+scores[i+2];
                }
            }

            //spare
            else if(scores[i]+scores[i+1]==10){
                totalScoreArr[i/2]=10+scores[i+2];
            }
            else{
                totalScoreArr[i/2]=scores[i]+scores[i+1];
            }
        

        cscoreObjs[i/2].GetComponent<TextMeshProUGUI>().text=totalScoreArr[i/2].ToString();

        if(totalScoreArr[i/2]>=10){
        finalScore[6+(i/2)*8]=intToChar[totalScoreArr[i/2]/10];
        finalScore[6+(i/2)*8+1]=intToChar[totalScoreArr[i/2]%10];
        }
        else{
        finalScore[6+(i/2)*8]=intToChar[totalScoreArr[i/2]];

        }
        }
        //25_ 10 5 9
        //9th frame
        if(scores[16]==10){
            if(scores[18]==10)
            totalScoreArr[8]=scores[16]+scores[18]+scores[19];
            else
            totalScoreArr[8]=scores[16]+scores[18];
            
        }
        else
            totalScoreArr[8]=scores[16]+scores[17];

        cscoreObjs[8].GetComponent<TextMeshProUGUI>().text=totalScoreArr[8].ToString();

        if(totalScoreArr[8]>=10){
        finalScore[70]=intToChar[totalScoreArr[8]/10];
        finalScore[71]=intToChar[totalScoreArr[8]%10];
        }
        else{
        finalScore[70]=intToChar[totalScoreArr[8]];

        }
        //10th frame
        totalScoreArr[9]=scores[18]+scores[19]+scores[20];

        cscoreObjs[9].GetComponent<TextMeshProUGUI>().text=totalScoreArr[9].ToString();

        if(totalScoreArr[9]>=10){
        finalScore[78]=intToChar[totalScoreArr[9]/10];
        finalScore[79]=intToChar[totalScoreArr[9]%10];
        }
        else{
        finalScore[78]=intToChar[totalScoreArr[9]];

        }
        for(int i=0;i<10;i++){
            finalScoreCalculation+=totalScoreArr[i];
        }
        Debug.Log("Final Score: "+finalScoreCalculation);
        int k=0;
        int j=0;
        final.text=finalScoreCalculation.ToString();
        congrats.text="Congrats, Your total score is "+finalScoreCalculation.ToString();

        setHighScore(finalScoreCalculation);
        setTopScore(finalScoreCalculation);
        while(finalScoreCalculation>0){
        j=finalScoreCalculation%10;
        finalScore[88-k]=intToChar[j];
        finalScoreCalculation/=10;
        k++;
        }
        string finalScoreCardString=new string(finalScore);
        totalScoreShowUI.text=finalScoreCardString;
        foreach (GameObject pin in pinObjects){
        Destroy(pin);
        }
        Destroy(ballObject);

        Debug.Log("End Game");
    }

    void setHighScore(int high){
        for(int i=0;i<10;i++){
            if(high>PlayerPrefs.GetInt($"h{i}")){
                for(int j=8;j>=i;j--){
                    int k=PlayerPrefs.GetInt($"h{j}");
                    PlayerPrefs.SetInt($"h{j+1}",k);
                }
                PlayerPrefs.SetInt($"h{i}",high);
                break;
            }
        }


    }


    void setTopScore(int top){
        bool topflag=true;
        
        for(int i=0;i<10;i++){
            if(PlayerPrefs.GetInt($"t{i}",0)>0){
                Debug.Log($"Top score{i}"+PlayerPrefs.GetInt($"t{i}"));
                // for(int j=8;j>=i;j--){
                //     int k=PlayerPrefs.GetInt($"t{j}");
                //     PlayerPrefs.SetInt($"t{j+1}",k);
                // }
                // PlayerPrefs.SetInt($"t{i}",top);
                continue;
            }

            else{
                topflag=false;
                PlayerPrefs.SetInt($"t{i}",top);
                break;
                }
        }

        if(topflag==true){
            for(int i=8;i>=0;i--){
                int k=PlayerPrefs.GetInt($"t{i}");
                PlayerPrefs.SetInt($"t{i+1}",k);

            }
            PlayerPrefs.SetInt("t0",top);
        }


    }
}
