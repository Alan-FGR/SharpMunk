# SharpMunk
Idiomatic and fast C# bindings for the Chipmunk physics engine

# Current State
Usable as a decent foundation to expand upon.

# Tests
These tests are based on the [official "Hello World"](https://chipmunk-physics.net/release/ChipmunkLatest-Docs/#Intro-HelloChipmunk)

C# Code:
```CSharp
static void Main(string[] args)
{
    cpSpace space = new cpSpace();
    space.SetGravity(new cpVect(0,-100));

    cpShape shape = cpShape.NewSegment(space.StaticBody, new cpVect(-20, 5), new cpVect(20, -5), 0);
    shape.SetFriction(1);

    space.AddShape(shape);
    
    double radius = 5;
    double mass = 1;
    double moment = cpUtil.MomentForCircle(mass, 0, radius, cpVect.Zero);

    cpBody ballBody = new cpBody(mass, moment);
    space.AddBody(ballBody);
    ballBody.Position = new cpVect(0, 15);

    cpShape ballShape = cpShape.NewCircle(ballBody, radius, cpVect.Zero);
    space.AddShape(ballShape);
    ballShape.SetFriction(0.7);

    double timeStep = 1 / 60d;
    for (double time = 0; time < 2; time+=timeStep)
    {
        cpVect pos = ballBody.Position;
        cpVect vel = ballBody.Velocity;
        Console.WriteLine("Time is {0:F2}. ballBody is at ({1:F2}, {2:F2}). It's velocity is ({3:F2}, {4:F2})",
            time, pos.X, pos.Y, vel.X, vel.Y
        );
        space.Step(timeStep);
    }
}
```
C# Output:
```
Time is 0.00. ballBody is at (0.00, 15.00). It's velocity is (0.00, 0.00)
Time is 0.02. ballBody is at (0.00, 15.00). It's velocity is (0.00, -1.67)
[...]
Time is 2.00. ballBody is at (28.93, -6.27). It's velocity is (26.68, -36.10)
```

C99 Code:
```C
int main(void) {

    cpVect gravity = cpv(0, -100);

    cpSpace *space = cpHastySpaceNew();
    cpSpaceSetGravity(space, gravity);
    cpHastySpaceSetThreads(space, 2);

    cpShape *ground = cpSegmentShapeNew(space->staticBody, cpv(-20, 5), cpv(20, -5), 0);
    cpShapeSetFriction(ground, 1);
    cpSpaceAddShape(space, ground);

    cpFloat radius = 5;
    cpFloat mass = 1;
    cpFloat moment = cpMomentForCircle(mass, 0, radius, cpvzero);

    cpBody *ballBody = cpSpaceAddBody(space, cpBodyNew(mass, moment));
    cpBodySetPosition(ballBody, cpv(0, 15));

    cpShape *ballShape = cpSpaceAddShape(space, cpCircleShapeNew(ballBody, radius, cpvzero));
    cpShapeSetFriction(ballShape, 0.7);

    cpFloat timeStep = 1.0 / 60.0;
    for (cpFloat time = 0; time < 2; time += timeStep) {
        cpVect pos = cpBodyGetPosition(ballBody);
        cpVect vel = cpBodyGetVelocity(ballBody);
        printf(
            "Time is %5.2f. ballBody is at (%5.2f, %5.2f). It's velocity is (%5.2f, %5.2f)\n",
            time, pos.x, pos.y, vel.x, vel.y
        );

        cpHastySpaceStep(space, timeStep);
    }
    
    cpShapeFree(ballShape);
    cpShapeFree(ground);
    cpSpaceFree(space);

    return 0;
}
```
C99 Output:
```
Time is  0.00. ballBody is at ( 0.00, 15.00). It's velocity is ( 0.00,  0.00)
Time is  0.02. ballBody is at ( 0.00, 15.00). It's velocity is ( 0.00, -1.67)
[...]
Time is  2.00. ballBody is at (28.93, -6.27). It's velocity is (26.68, -36.10)
```
