model laboratory3
  Modelica.Electrical.Analog.Basic.Ground ground annotation(
    Placement(visible = true, transformation(origin = {-88, -54}, extent = {{-10, -10}, {10, 10}}, rotation = 0)));
  Modelica.Electrical.Analog.Basic.Resistor resistor(R = 1)  annotation(
    Placement(visible = true, transformation(origin = {-52, 72}, extent = {{10, -10}, {-10, 10}}, rotation = 0)));
  Modelica.Electrical.Analog.Basic.Resistor resistor1(R = 1)  annotation(
    Placement(visible = true, transformation(origin = {54, 22}, extent = {{-10, -10}, {10, 10}}, rotation = 90)));
  Modelica.Electrical.Analog.Sources.SineVoltage sineVoltage(V = 1, phase(displayUnit = "rad") = 1)  annotation(
    Placement(visible = true, transformation(origin = {-88, 8}, extent = {{10, -10}, {-10, 10}}, rotation = 90)));
  Modelica.Electrical.Analog.Basic.Inductor inductor(L = 1)  annotation(
    Placement(visible = true, transformation(origin = {-58, -20}, extent = {{-10, -10}, {10, 10}}, rotation = 0)));
  Modelica.Electrical.Analog.Basic.Inductor inductor1(L = 1)  annotation(
    Placement(visible = true, transformation(origin = {-24, 22}, extent = {{-10, -10}, {10, 10}}, rotation = 90)));
  Modelica.Electrical.Analog.Ideal.IdealDiode diode annotation(
    Placement(visible = true, transformation(origin = {26, 22}, extent = {{-10, -10}, {10, 10}}, rotation = 90)));
  Modelica.Electrical.Analog.Basic.Capacitor capacitor(C = 1)  annotation(
    Placement(visible = true, transformation(origin = {8, -4}, extent = {{-10, -10}, {10, 10}}, rotation = 0)));
equation
  connect(sineVoltage.p, resistor.n) annotation(
    Line(points = {{-88, 18}, {-88, 72}, {-62, 72}}, color = {0, 0, 255}));
  connect(resistor.p, resistor1.n) annotation(
    Line(points = {{-42, 72}, {12, 72}, {12, 46}, {54, 46}, {54, 32}}, color = {0, 0, 255}));
  connect(resistor.p, inductor1.n) annotation(
    Line(points = {{-42, 72}, {12, 72}, {12, 46}, {-24, 46}, {-24, 32}}, color = {0, 0, 255}));
  connect(resistor.p, diode.n) annotation(
    Line(points = {{-42, 72}, {12, 72}, {12, 46}, {26, 46}, {26, 32}}, color = {0, 0, 255}));
  connect(diode.p, capacitor.n) annotation(
    Line(points = {{26, 12}, {26, -4}, {18, -4}}, color = {0, 0, 255}));
  connect(resistor1.p, capacitor.n) annotation(
    Line(points = {{54, 12}, {54, -4}, {18, -4}}, color = {0, 0, 255}));
  connect(inductor1.p, inductor.n) annotation(
    Line(points = {{-24, 12}, {-24, -4}, {-12, -4}, {-12, -20}, {-48, -20}}, color = {0, 0, 255}));
  connect(capacitor.p, inductor.n) annotation(
    Line(points = {{-2, -4}, {-12, -4}, {-12, -20}, {-48, -20}}, color = {0, 0, 255}));
  connect(inductor.p, sineVoltage.n) annotation(
    Line(points = {{-68, -20}, {-88, -20}, {-88, -2}}, color = {0, 0, 255}));
  connect(ground.p, sineVoltage.n) annotation(
    Line(points = {{-88, -44}, {-88, -2}}, color = {0, 0, 255}));

annotation(
    uses(Modelica(version = "4.0.0")));
end laboratory3;
