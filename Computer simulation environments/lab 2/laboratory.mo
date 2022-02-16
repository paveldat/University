model laboratory
  Modelica.Blocks.Sources.Step step(height = 3)  annotation(
    Placement(visible = true, transformation(origin = {-130, 4}, extent = {{-10, -10}, {10, 10}}, rotation = 0)));
  Modelica.Blocks.Math.Feedback feedback annotation(
    Placement(visible = true, transformation(origin = {-88, 4}, extent = {{-10, -10}, {10, 10}}, rotation = 0)));
  Modelica.Blocks.Math.Gain gain(k = 2)  annotation(
    Placement(visible = true, transformation(origin = {-48, 4}, extent = {{-10, -10}, {10, 10}}, rotation = 0)));
  Modelica.Blocks.Continuous.FirstOrder firstOrder(T = 0.1, k = 2)  annotation(
    Placement(visible = true, transformation(origin = {-6, 4}, extent = {{-10, -10}, {10, 10}}, rotation = 0)));
  Modelica.Blocks.Continuous.FirstOrder firstOrder1(T = 0.2, k = 1.1)  annotation(
    Placement(visible = true, transformation(origin = {32, 4}, extent = {{-10, -10}, {10, 10}}, rotation = 0)));
  Modelica.Blocks.Continuous.FirstOrder firstOrder2(T = 0.8, k = 1.5)  annotation(
    Placement(visible = true, transformation(origin = {68, 4}, extent = {{-10, -10}, {10, 10}}, rotation = 0)));
  Modelica.Blocks.Math.Add add annotation(
    Placement(visible = true, transformation(origin = {118, 10}, extent = {{-10, -10}, {10, 10}}, rotation = 0)));
  Modelica.Blocks.Sources.Step step1(height = 0.6, startTime = 5)  annotation(
    Placement(visible = true, transformation(origin = {68, 70}, extent = {{-10, -10}, {10, 10}}, rotation = 0)));
  Modelica.Blocks.Math.Gain gain1(k = 0.5)  annotation(
    Placement(visible = true, transformation(origin = {52, -48}, extent = {{-10, -10}, {10, 10}}, rotation = 180)));
equation
  connect(step.y, feedback.u1) annotation(
    Line(points = {{-119, 4}, {-97, 4}}, color = {0, 0, 127}));
  connect(feedback.y, gain.u) annotation(
    Line(points = {{-79, 4}, {-61, 4}}, color = {0, 0, 127}));
  connect(gain.y, firstOrder.u) annotation(
    Line(points = {{-37, 4}, {-19, 4}}, color = {0, 0, 127}));
  connect(firstOrder.y, firstOrder1.u) annotation(
    Line(points = {{5, 4}, {19, 4}}, color = {0, 0, 127}));
  connect(firstOrder1.y, firstOrder2.u) annotation(
    Line(points = {{43, 4}, {55, 4}}, color = {0, 0, 127}));
  connect(firstOrder2.y, add.u2) annotation(
    Line(points = {{80, 4}, {106, 4}}, color = {0, 0, 127}));
  connect(add.y, gain1.u) annotation(
    Line(points = {{129, 10}, {138, 10}, {138, -48}, {64, -48}}, color = {0, 0, 127}));
  connect(step1.y, add.u1) annotation(
    Line(points = {{80, 70}, {92, 70}, {92, 16}, {106, 16}}, color = {0, 0, 127}));
  connect(gain1.y, feedback.u2) annotation(
    Line(points = {{42, -48}, {-88, -48}, {-88, -4}}, color = {0, 0, 127}));

annotation(
    uses(Modelica(version = "4.0.0")));
end laboratory;
