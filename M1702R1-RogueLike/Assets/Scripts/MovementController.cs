//using system.collections;
//using system.net.websockets;
//using unity.plasticscm.editor.webapi;
//using unity.visualscripting;
//using unityengine;
//using unityengine.eventsystems;
//using unityengine.inputsystem;
//using unityengine.playables;
//using static unityeditor.timeline.timelineplaybackcontrols;

//public class movementcontroller : monobehaviour
//{

//    public static movementcontroller instance;

//    public animator animcontroller;

//    private components
//    private playercontrols playercontrols;
//    private rigidbody2d rb;

//    private camera main;

//    private gameobjects
//    public weapon weaponparent;
//    public static movementcontroller player;

//    private variables
//    public vector2 direction = vector2.zero;
//    public vector2 lastmovedirection;

//    [serializefield] private bullet bullet;
//    [serializefield] private transform bulletdirection;

//    private bool canshoot = true;


//    public transform aim;



//    private readonly int speed = 5;

//    private readonly float meleecd = .5f;

//    private bool meleeisallowed = true;
//    private bool rangedisallowed = true;




//  

//        playercontrols.gameplay.rangeattack.performed += playershoot;


//  
//  

//   
//  

//    private ienumerator rangedattackanimation()
//    {
//        rangedisallowed = false;

//        animcontroller.setbool("rangeattack", true);

//        yield return new waitforseconds(0.583f);

//        animcontroller.setbool("rangeattack", false);
//        rangedisallowed = true;
//    }

//    private vector2 getmouseposition()
//    {
//        vector3 mousepos = playercontrols.gameplay.followmouse.readvalue<vector2>();
//        mousepos.z = camera.main.nearclipplane;
//        return camera.main.screentoworldpoint(mousepos);
//    }
//    private void moveplayer()
//    {

//        if (direction.magnitude < 0.1) aim.rotation = quaternion.lookrotation(vector3.back, lastmovedirection * -1);
//        else aim.rotation = quaternion.lookrotation(vector3.back, direction * -1);

//        //   rb.velocity = new vector2(direction.x * speed, direction.y * speed);
//    }

//    private void playershoot(inputaction.callbackcontext context)
//    {
//        if (!canshoot) return;


//        vector2 mouseposition = playercontrols.gameplay.followmouse.readvalue<vector2>();
//        mouseposition = camera.main.screentoworldpoint(mouseposition);
//        bullet g = instantiate(bullet, bulletdirection.position, bulletdirection.rotation);

//        debug.log("se ha activado la bala");

//        startcoroutine(rangedattackanimation());

//        g.gameobject.setactive(true);
//        g.directionbullet(mouseposition);
//        startcoroutine(canshoot());

//    }
//    ienumerator canshoot()
//    {
//        canshoot = false;
//        yield return new waitforseconds(2f);
//        canshoot = true;
//    }

//    private void mouseposition()
//    {
//        //rotation
//        vector2 mousescreenposition = playercontrols.gameplay.followmouse.readvalue<vector2>();
//        vector3 mouseworldposition = main.screentoworldpoint(mousescreenposition);
//        vector3 targetdirection = mouseworldposition - transform.position;
//        float angle = mathf.atan2(targetdirection.y, targetdirection.x);
//        transform.rotation = quaternion.euler(new vector3(0f, 0f, angle));
//    }

//}
