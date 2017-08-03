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
Initializing cpSpace - Chipmunk v7.0.1 (Debug Enabled)
Compile with -DNDEBUG defined to disable debug mode and runtime assertion checks

Time is 0.00. ballBody is at (0.00, 15.00). It's velocity is (0.00, 0.00)
Time is 0.02. ballBody is at (0.00, 15.00). It's velocity is (0.00, -1.67)
Time is 0.03. ballBody is at (0.00, 14.97). It's velocity is (0.00, -3.33)
Time is 0.05. ballBody is at (0.00, 14.92). It's velocity is (0.00, -5.00)
Time is 0.07. ballBody is at (0.00, 14.83). It's velocity is (0.00, -6.67)
Time is 0.08. ballBody is at (0.00, 14.72). It's velocity is (0.00, -8.33)
Time is 0.10. ballBody is at (0.00, 14.58). It's velocity is (0.00, -10.00)
Time is 0.12. ballBody is at (0.00, 14.42). It's velocity is (0.00, -11.67)
Time is 0.13. ballBody is at (0.00, 14.22). It's velocity is (0.00, -13.33)
Time is 0.15. ballBody is at (0.00, 14.00). It's velocity is (0.00, -15.00)
Time is 0.17. ballBody is at (0.00, 13.75). It's velocity is (0.00, -16.67)
Time is 0.18. ballBody is at (0.00, 13.47). It's velocity is (0.00, -18.33)
Time is 0.20. ballBody is at (0.00, 13.17). It's velocity is (0.00, -20.00)
Time is 0.22. ballBody is at (0.00, 12.83). It's velocity is (0.00, -21.67)
Time is 0.23. ballBody is at (0.00, 12.47). It's velocity is (0.00, -23.33)
Time is 0.25. ballBody is at (0.00, 12.08). It's velocity is (0.00, -25.00)
Time is 0.27. ballBody is at (0.00, 11.67). It's velocity is (0.00, -26.67)
Time is 0.28. ballBody is at (0.00, 11.22). It's velocity is (0.00, -28.33)
Time is 0.30. ballBody is at (0.00, 10.75). It's velocity is (0.00, -30.00)
Time is 0.32. ballBody is at (0.00, 10.25). It's velocity is (0.00, -31.67)
Time is 0.33. ballBody is at (0.00, 9.72). It's velocity is (0.00, -33.33)
Time is 0.35. ballBody is at (0.00, 9.17). It's velocity is (0.00, -35.00)
Time is 0.37. ballBody is at (0.00, 8.58). It's velocity is (0.00, -36.67)
Time is 0.38. ballBody is at (0.00, 7.97). It's velocity is (0.00, -38.33)
Time is 0.40. ballBody is at (0.00, 7.33). It's velocity is (0.00, -40.00)
Time is 0.42. ballBody is at (0.00, 6.67). It's velocity is (0.00, -41.67)
Time is 0.43. ballBody is at (0.00, 5.97). It's velocity is (0.00, -43.33)
Time is 0.45. ballBody is at (0.00, 5.25). It's velocity is (0.00, -45.00)
Time is 0.47. ballBody is at (0.00, 4.50). It's velocity is (7.32, -1.83)
Time is 0.48. ballBody is at (0.13, 4.52). It's velocity is (7.58, -1.90)
Time is 0.50. ballBody is at (0.27, 4.54). It's velocity is (7.84, -1.96)
Time is 0.52. ballBody is at (0.41, 4.55). It's velocity is (8.10, -2.03)
Time is 0.53. ballBody is at (0.56, 4.55). It's velocity is (8.37, -2.09)
Time is 0.55. ballBody is at (0.71, 4.55). It's velocity is (8.63, -2.16)
Time is 0.57. ballBody is at (0.86, 4.54). It's velocity is (8.89, -2.22)
Time is 0.58. ballBody is at (1.01, 4.53). It's velocity is (9.15, -2.29)
Time is 0.60. ballBody is at (1.17, 4.52). It's velocity is (9.41, -2.35)
Time is 0.62. ballBody is at (1.33, 4.50). It's velocity is (9.67, -2.42)
Time is 0.63. ballBody is at (1.50, 4.48). It's velocity is (9.93, -2.48)
Time is 0.65. ballBody is at (1.67, 4.46). It's velocity is (10.20, -2.55)
Time is 0.67. ballBody is at (1.84, 4.43). It's velocity is (10.46, -2.61)
Time is 0.68. ballBody is at (2.02, 4.41). It's velocity is (10.72, -2.68)
Time is 0.70. ballBody is at (2.20, 4.37). It's velocity is (10.98, -2.75)
Time is 0.72. ballBody is at (2.39, 4.34). It's velocity is (11.24, -2.81)
Time is 0.73. ballBody is at (2.58, 4.30). It's velocity is (11.50, -2.88)
Time is 0.75. ballBody is at (2.77, 4.27). It's velocity is (11.76, -2.94)
Time is 0.77. ballBody is at (2.97, 4.22). It's velocity is (12.03, -3.01)
Time is 0.78. ballBody is at (3.18, 4.18). It's velocity is (12.29, -3.07)
Time is 0.80. ballBody is at (3.38, 4.14). It's velocity is (12.55, -3.14)
Time is 0.82. ballBody is at (3.59, 4.09). It's velocity is (12.81, -3.20)
Time is 0.83. ballBody is at (3.81, 4.04). It's velocity is (13.07, -3.27)
Time is 0.85. ballBody is at (4.03, 4.00). It's velocity is (13.33, -3.33)
Time is 0.87. ballBody is at (4.25, 3.94). It's velocity is (13.59, -3.40)
Time is 0.88. ballBody is at (4.48, 3.89). It's velocity is (13.86, -3.46)
Time is 0.90. ballBody is at (4.71, 3.84). It's velocity is (14.12, -3.53)
Time is 0.92. ballBody is at (4.95, 3.78). It's velocity is (14.38, -3.59)
Time is 0.93. ballBody is at (5.19, 3.73). It's velocity is (14.64, -3.66)
Time is 0.95. ballBody is at (5.43, 3.67). It's velocity is (14.90, -3.73)
Time is 0.97. ballBody is at (5.68, 3.61). It's velocity is (15.16, -3.79)
Time is 0.98. ballBody is at (5.93, 3.55). It's velocity is (15.42, -3.86)
Time is 1.00. ballBody is at (6.19, 3.48). It's velocity is (15.69, -3.92)
Time is 1.02. ballBody is at (6.45, 3.42). It's velocity is (15.95, -3.99)
Time is 1.03. ballBody is at (6.72, 3.36). It's velocity is (16.21, -4.05)
Time is 1.05. ballBody is at (6.99, 3.29). It's velocity is (16.47, -4.12)
Time is 1.07. ballBody is at (7.26, 3.22). It's velocity is (16.73, -4.18)
Time is 1.08. ballBody is at (7.54, 3.15). It's velocity is (16.99, -4.25)
Time is 1.10. ballBody is at (7.83, 3.08). It's velocity is (17.25, -4.31)
Time is 1.12. ballBody is at (8.11, 3.01). It's velocity is (17.52, -4.38)
Time is 1.13. ballBody is at (8.41, 2.94). It's velocity is (17.78, -4.44)
Time is 1.15. ballBody is at (8.70, 2.87). It's velocity is (18.04, -4.51)
Time is 1.17. ballBody is at (9.00, 2.79). It's velocity is (18.30, -4.58)
Time is 1.18. ballBody is at (9.31, 2.72). It's velocity is (18.56, -4.64)
Time is 1.20. ballBody is at (9.62, 2.64). It's velocity is (18.82, -4.71)
Time is 1.22. ballBody is at (9.93, 2.56). It's velocity is (19.08, -4.77)
Time is 1.23. ballBody is at (10.25, 2.48). It's velocity is (19.35, -4.84)
Time is 1.25. ballBody is at (10.57, 2.40). It's velocity is (19.61, -4.90)
Time is 1.27. ballBody is at (10.90, 2.32). It's velocity is (19.87, -4.97)
Time is 1.28. ballBody is at (11.23, 2.24). It's velocity is (20.13, -5.03)
Time is 1.30. ballBody is at (11.57, 2.16). It's velocity is (20.39, -5.10)
Time is 1.32. ballBody is at (11.91, 2.07). It's velocity is (20.65, -5.16)
Time is 1.33. ballBody is at (12.25, 1.99). It's velocity is (20.92, -5.23)
Time is 1.35. ballBody is at (12.60, 1.90). It's velocity is (21.18, -5.29)
Time is 1.37. ballBody is at (12.95, 1.81). It's velocity is (21.44, -5.36)
Time is 1.38. ballBody is at (13.31, 1.72). It's velocity is (21.70, -5.42)
Time is 1.40. ballBody is at (13.67, 1.63). It's velocity is (21.96, -5.49)
Time is 1.42. ballBody is at (14.04, 1.54). It's velocity is (22.22, -5.56)
Time is 1.43. ballBody is at (14.41, 1.45). It's velocity is (22.48, -5.62)
Time is 1.45. ballBody is at (14.78, 1.35). It's velocity is (22.75, -5.69)
Time is 1.47. ballBody is at (15.16, 1.26). It's velocity is (23.01, -5.75)
Time is 1.48. ballBody is at (15.55, 1.16). It's velocity is (23.27, -5.82)
Time is 1.50. ballBody is at (15.93, 1.07). It's velocity is (23.53, -5.88)
Time is 1.52. ballBody is at (16.33, 0.97). It's velocity is (23.79, -5.95)
Time is 1.53. ballBody is at (16.72, 0.87). It's velocity is (24.05, -6.01)
Time is 1.55. ballBody is at (17.12, 0.77). It's velocity is (24.31, -6.08)
Time is 1.57. ballBody is at (17.53, 0.67). It's velocity is (24.58, -6.14)
Time is 1.58. ballBody is at (17.94, 0.57). It's velocity is (24.84, -6.21)
Time is 1.60. ballBody is at (18.35, 0.46). It's velocity is (25.10, -6.27)
Time is 1.62. ballBody is at (18.77, 0.36). It's velocity is (25.36, -6.34)
Time is 1.63. ballBody is at (19.19, 0.25). It's velocity is (25.62, -6.41)
Time is 1.65. ballBody is at (19.62, 0.15). It's velocity is (25.88, -6.47)
Time is 1.67. ballBody is at (20.05, 0.04). It's velocity is (26.14, -6.54)
Time is 1.68. ballBody is at (20.49, -0.07). It's velocity is (26.41, -6.60)
Time is 1.70. ballBody is at (20.93, -0.18). It's velocity is (26.67, -6.67)
Time is 1.72. ballBody is at (21.37, -0.29). It's velocity is (26.68, -7.77)
Time is 1.73. ballBody is at (21.82, -0.42). It's velocity is (26.68, -9.44)
Time is 1.75. ballBody is at (22.26, -0.58). It's velocity is (26.68, -11.10)
Time is 1.77. ballBody is at (22.71, -0.76). It's velocity is (26.68, -12.77)
Time is 1.78. ballBody is at (23.15, -0.98). It's velocity is (26.68, -14.44)
Time is 1.80. ballBody is at (23.59, -1.22). It's velocity is (26.68, -16.10)
Time is 1.82. ballBody is at (24.04, -1.49). It's velocity is (26.68, -17.77)
Time is 1.83. ballBody is at (24.48, -1.78). It's velocity is (26.68, -19.44)
Time is 1.85. ballBody is at (24.93, -2.11). It's velocity is (26.68, -21.10)
Time is 1.87. ballBody is at (25.37, -2.46). It's velocity is (26.68, -22.77)
Time is 1.88. ballBody is at (25.82, -2.84). It's velocity is (26.68, -24.44)
Time is 1.90. ballBody is at (26.26, -3.24). It's velocity is (26.68, -26.10)
Time is 1.92. ballBody is at (26.71, -3.68). It's velocity is (26.68, -27.77)
Time is 1.93. ballBody is at (27.15, -4.14). It's velocity is (26.68, -29.44)
Time is 1.95. ballBody is at (27.60, -4.63). It's velocity is (26.68, -31.10)
Time is 1.97. ballBody is at (28.04, -5.15). It's velocity is (26.68, -32.77)
Time is 1.98. ballBody is at (28.48, -5.70). It's velocity is (26.68, -34.44)
Time is 2.00. ballBody is at (28.93, -6.27). It's velocity is (26.68, -36.10)
```

C99 Code:
```C99
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
Initializing cpSpace - Chipmunk v7.0.1 (Debug Enabled)
Compile with -DNDEBUG defined to disable debug mode and runtime assertion checks

Time is  0.00. ballBody is at ( 0.00, 15.00). It's velocity is ( 0.00,  0.00)
Time is  0.02. ballBody is at ( 0.00, 15.00). It's velocity is ( 0.00, -1.67)
Time is  0.03. ballBody is at ( 0.00, 14.97). It's velocity is ( 0.00, -3.33)
Time is  0.05. ballBody is at ( 0.00, 14.92). It's velocity is ( 0.00, -5.00)
Time is  0.07. ballBody is at ( 0.00, 14.83). It's velocity is ( 0.00, -6.67)
Time is  0.08. ballBody is at ( 0.00, 14.72). It's velocity is ( 0.00, -8.33)
Time is  0.10. ballBody is at ( 0.00, 14.58). It's velocity is ( 0.00, -10.00)
Time is  0.12. ballBody is at ( 0.00, 14.42). It's velocity is ( 0.00, -11.67)
Time is  0.13. ballBody is at ( 0.00, 14.22). It's velocity is ( 0.00, -13.33)
Time is  0.15. ballBody is at ( 0.00, 14.00). It's velocity is ( 0.00, -15.00)
Time is  0.17. ballBody is at ( 0.00, 13.75). It's velocity is ( 0.00, -16.67)
Time is  0.18. ballBody is at ( 0.00, 13.47). It's velocity is ( 0.00, -18.33)
Time is  0.20. ballBody is at ( 0.00, 13.17). It's velocity is ( 0.00, -20.00)
Time is  0.22. ballBody is at ( 0.00, 12.83). It's velocity is ( 0.00, -21.67)
Time is  0.23. ballBody is at ( 0.00, 12.47). It's velocity is ( 0.00, -23.33)
Time is  0.25. ballBody is at ( 0.00, 12.08). It's velocity is ( 0.00, -25.00)
Time is  0.27. ballBody is at ( 0.00, 11.67). It's velocity is ( 0.00, -26.67)
Time is  0.28. ballBody is at ( 0.00, 11.22). It's velocity is ( 0.00, -28.33)
Time is  0.30. ballBody is at ( 0.00, 10.75). It's velocity is ( 0.00, -30.00)
Time is  0.32. ballBody is at ( 0.00, 10.25). It's velocity is ( 0.00, -31.67)
Time is  0.33. ballBody is at ( 0.00,  9.72). It's velocity is ( 0.00, -33.33)
Time is  0.35. ballBody is at ( 0.00,  9.17). It's velocity is ( 0.00, -35.00)
Time is  0.37. ballBody is at ( 0.00,  8.58). It's velocity is ( 0.00, -36.67)
Time is  0.38. ballBody is at ( 0.00,  7.97). It's velocity is ( 0.00, -38.33)
Time is  0.40. ballBody is at ( 0.00,  7.33). It's velocity is ( 0.00, -40.00)
Time is  0.42. ballBody is at ( 0.00,  6.67). It's velocity is ( 0.00, -41.67)
Time is  0.43. ballBody is at ( 0.00,  5.97). It's velocity is ( 0.00, -43.33)
Time is  0.45. ballBody is at ( 0.00,  5.25). It's velocity is ( 0.00, -45.00)
Time is  0.47. ballBody is at ( 0.00,  4.50). It's velocity is ( 7.32, -1.83)
Time is  0.48. ballBody is at ( 0.13,  4.52). It's velocity is ( 7.58, -1.90)
Time is  0.50. ballBody is at ( 0.27,  4.54). It's velocity is ( 7.84, -1.96)
Time is  0.52. ballBody is at ( 0.41,  4.55). It's velocity is ( 8.10, -2.03)
Time is  0.53. ballBody is at ( 0.56,  4.55). It's velocity is ( 8.37, -2.09)
Time is  0.55. ballBody is at ( 0.71,  4.55). It's velocity is ( 8.63, -2.16)
Time is  0.57. ballBody is at ( 0.86,  4.54). It's velocity is ( 8.89, -2.22)
Time is  0.58. ballBody is at ( 1.01,  4.53). It's velocity is ( 9.15, -2.29)
Time is  0.60. ballBody is at ( 1.17,  4.52). It's velocity is ( 9.41, -2.35)
Time is  0.62. ballBody is at ( 1.33,  4.50). It's velocity is ( 9.67, -2.42)
Time is  0.63. ballBody is at ( 1.50,  4.48). It's velocity is ( 9.93, -2.48)
Time is  0.65. ballBody is at ( 1.67,  4.46). It's velocity is (10.20, -2.55)
Time is  0.67. ballBody is at ( 1.84,  4.43). It's velocity is (10.46, -2.61)
Time is  0.68. ballBody is at ( 2.02,  4.41). It's velocity is (10.72, -2.68)
Time is  0.70. ballBody is at ( 2.20,  4.37). It's velocity is (10.98, -2.75)
Time is  0.72. ballBody is at ( 2.39,  4.34). It's velocity is (11.24, -2.81)
Time is  0.73. ballBody is at ( 2.58,  4.30). It's velocity is (11.50, -2.88)
Time is  0.75. ballBody is at ( 2.77,  4.27). It's velocity is (11.76, -2.94)
Time is  0.77. ballBody is at ( 2.97,  4.22). It's velocity is (12.03, -3.01)
Time is  0.78. ballBody is at ( 3.18,  4.18). It's velocity is (12.29, -3.07)
Time is  0.80. ballBody is at ( 3.38,  4.14). It's velocity is (12.55, -3.14)
Time is  0.82. ballBody is at ( 3.59,  4.09). It's velocity is (12.81, -3.20)
Time is  0.83. ballBody is at ( 3.81,  4.04). It's velocity is (13.07, -3.27)
Time is  0.85. ballBody is at ( 4.03,  4.00). It's velocity is (13.33, -3.33)
Time is  0.87. ballBody is at ( 4.25,  3.94). It's velocity is (13.59, -3.40)
Time is  0.88. ballBody is at ( 4.48,  3.89). It's velocity is (13.86, -3.46)
Time is  0.90. ballBody is at ( 4.71,  3.84). It's velocity is (14.12, -3.53)
Time is  0.92. ballBody is at ( 4.95,  3.78). It's velocity is (14.38, -3.59)
Time is  0.93. ballBody is at ( 5.19,  3.73). It's velocity is (14.64, -3.66)
Time is  0.95. ballBody is at ( 5.43,  3.67). It's velocity is (14.90, -3.73)
Time is  0.97. ballBody is at ( 5.68,  3.61). It's velocity is (15.16, -3.79)
Time is  0.98. ballBody is at ( 5.93,  3.55). It's velocity is (15.42, -3.86)
Time is  1.00. ballBody is at ( 6.19,  3.48). It's velocity is (15.69, -3.92)
Time is  1.02. ballBody is at ( 6.45,  3.42). It's velocity is (15.95, -3.99)
Time is  1.03. ballBody is at ( 6.72,  3.36). It's velocity is (16.21, -4.05)
Time is  1.05. ballBody is at ( 6.99,  3.29). It's velocity is (16.47, -4.12)
Time is  1.07. ballBody is at ( 7.26,  3.22). It's velocity is (16.73, -4.18)
Time is  1.08. ballBody is at ( 7.54,  3.15). It's velocity is (16.99, -4.25)
Time is  1.10. ballBody is at ( 7.83,  3.08). It's velocity is (17.25, -4.31)
Time is  1.12. ballBody is at ( 8.11,  3.01). It's velocity is (17.52, -4.38)
Time is  1.13. ballBody is at ( 8.41,  2.94). It's velocity is (17.78, -4.44)
Time is  1.15. ballBody is at ( 8.70,  2.87). It's velocity is (18.04, -4.51)
Time is  1.17. ballBody is at ( 9.00,  2.79). It's velocity is (18.30, -4.58)
Time is  1.18. ballBody is at ( 9.31,  2.72). It's velocity is (18.56, -4.64)
Time is  1.20. ballBody is at ( 9.62,  2.64). It's velocity is (18.82, -4.71)
Time is  1.22. ballBody is at ( 9.93,  2.56). It's velocity is (19.08, -4.77)
Time is  1.23. ballBody is at (10.25,  2.48). It's velocity is (19.35, -4.84)
Time is  1.25. ballBody is at (10.57,  2.40). It's velocity is (19.61, -4.90)
Time is  1.27. ballBody is at (10.90,  2.32). It's velocity is (19.87, -4.97)
Time is  1.28. ballBody is at (11.23,  2.24). It's velocity is (20.13, -5.03)
Time is  1.30. ballBody is at (11.57,  2.16). It's velocity is (20.39, -5.10)
Time is  1.32. ballBody is at (11.91,  2.07). It's velocity is (20.65, -5.16)
Time is  1.33. ballBody is at (12.25,  1.99). It's velocity is (20.92, -5.23)
Time is  1.35. ballBody is at (12.60,  1.90). It's velocity is (21.18, -5.29)
Time is  1.37. ballBody is at (12.95,  1.81). It's velocity is (21.44, -5.36)
Time is  1.38. ballBody is at (13.31,  1.72). It's velocity is (21.70, -5.42)
Time is  1.40. ballBody is at (13.67,  1.63). It's velocity is (21.96, -5.49)
Time is  1.42. ballBody is at (14.04,  1.54). It's velocity is (22.22, -5.56)
Time is  1.43. ballBody is at (14.41,  1.45). It's velocity is (22.48, -5.62)
Time is  1.45. ballBody is at (14.78,  1.35). It's velocity is (22.75, -5.69)
Time is  1.47. ballBody is at (15.16,  1.26). It's velocity is (23.01, -5.75)
Time is  1.48. ballBody is at (15.55,  1.16). It's velocity is (23.27, -5.82)
Time is  1.50. ballBody is at (15.93,  1.07). It's velocity is (23.53, -5.88)
Time is  1.52. ballBody is at (16.33,  0.97). It's velocity is (23.79, -5.95)
Time is  1.53. ballBody is at (16.72,  0.87). It's velocity is (24.05, -6.01)
Time is  1.55. ballBody is at (17.12,  0.77). It's velocity is (24.31, -6.08)
Time is  1.57. ballBody is at (17.53,  0.67). It's velocity is (24.58, -6.14)
Time is  1.58. ballBody is at (17.94,  0.57). It's velocity is (24.84, -6.21)
Time is  1.60. ballBody is at (18.35,  0.46). It's velocity is (25.10, -6.27)
Time is  1.62. ballBody is at (18.77,  0.36). It's velocity is (25.36, -6.34)
Time is  1.63. ballBody is at (19.19,  0.25). It's velocity is (25.62, -6.41)
Time is  1.65. ballBody is at (19.62,  0.15). It's velocity is (25.88, -6.47)
Time is  1.67. ballBody is at (20.05,  0.04). It's velocity is (26.14, -6.54)
Time is  1.68. ballBody is at (20.49, -0.07). It's velocity is (26.41, -6.60)
Time is  1.70. ballBody is at (20.93, -0.18). It's velocity is (26.67, -6.67)
Time is  1.72. ballBody is at (21.37, -0.29). It's velocity is (26.68, -7.77)
Time is  1.73. ballBody is at (21.82, -0.42). It's velocity is (26.68, -9.44)
Time is  1.75. ballBody is at (22.26, -0.58). It's velocity is (26.68, -11.10)
Time is  1.77. ballBody is at (22.71, -0.76). It's velocity is (26.68, -12.77)
Time is  1.78. ballBody is at (23.15, -0.98). It's velocity is (26.68, -14.44)
Time is  1.80. ballBody is at (23.59, -1.22). It's velocity is (26.68, -16.10)
Time is  1.82. ballBody is at (24.04, -1.49). It's velocity is (26.68, -17.77)
Time is  1.83. ballBody is at (24.48, -1.78). It's velocity is (26.68, -19.44)
Time is  1.85. ballBody is at (24.93, -2.11). It's velocity is (26.68, -21.10)
Time is  1.87. ballBody is at (25.37, -2.46). It's velocity is (26.68, -22.77)
Time is  1.88. ballBody is at (25.82, -2.84). It's velocity is (26.68, -24.44)
Time is  1.90. ballBody is at (26.26, -3.24). It's velocity is (26.68, -26.10)
Time is  1.92. ballBody is at (26.71, -3.68). It's velocity is (26.68, -27.77)
Time is  1.93. ballBody is at (27.15, -4.14). It's velocity is (26.68, -29.44)
Time is  1.95. ballBody is at (27.60, -4.63). It's velocity is (26.68, -31.10)
Time is  1.97. ballBody is at (28.04, -5.15). It's velocity is (26.68, -32.77)
Time is  1.98. ballBody is at (28.48, -5.70). It's velocity is (26.68, -34.44)
Time is  2.00. ballBody is at (28.93, -6.27). It's velocity is (26.68, -36.10)
```