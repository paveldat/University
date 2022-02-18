# Task 2
Реализовать в спецификации NuSMV алгоритм Деккера. Провести его
тестирование для двух процессов. Проверить, что он удовлетворяет свойствам
взаимного исключения и отсутствия голодания.

**Алгоритм Деккера на псевдокоде**
```
flag[0] := false
 flag[1] := false
 turn := 0   // or 1
```
p0:
```
flag[0] := true
     while flag[1] = true {
         if turn = 1 {
            flag[0] := false
            while turn = 1 {}
            flag[0] := true
         }
     }
 
    // критическая секция
    ...
    turn := 1
    flag[0] := false
    // конец критической секции
    ...
```
p1:
```
 flag[1] := true
     while flag[0] = true {
         if turn = 0 {
             flag[1] := false
             while turn = 0 {}
             flag[1] := true
         }
     }

     // критическая секция
     ...
     turn := 0
     flag[1] := false
     // конец критической секции
     ...
```
# Report
Check "Report.docx"
# Author
Pavel Dat