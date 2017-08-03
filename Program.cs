using System;

static class Program
{
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

        Console.ReadKey();
    }


}
