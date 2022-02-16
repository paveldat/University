model laboratory1
  parameter Real a=2;
  parameter Real d=4;
  parameter Real k=4;
  parameter Real b=2;
  parameter Real k1=1;
  parameter Real k2=1;
  Real x(start=-10);
  Real y(start=-10);
  Real F;
equation
  if x<-d then
    F=-k;
  elseif x>d then
    F=k;
  elseif x<-a then
    F=x-b;
  elseif x>a then
    F=x+b;
  else
    F=0;
  end if;
   
  der(x)=y;
  der(y)=-k1*F-k2*x;
   
end laboratory1;
