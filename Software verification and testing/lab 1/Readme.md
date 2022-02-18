# Task 1
Дана модель:
```
MODULE User(auth)
VAR
status: { NonCritical, Trying, Critical };
ASSIGN
init(status) := NonCritical;
next(status) :=
case
status = NonCritical : { NonCritical, Trying };
status = Trying :
case
next(auth) = 0 : Trying;
next(auth) = 1 : Critical;
esac;
status = Critical : { Critical, NonCritical};
esac;
VAR
req: boolean;
ASSIGN
req := status in { Trying, Critical };
--------------------------------------------------
---- The Arbiter ---------------------------------
--------------------------------------------------
MODULE Arbiter(req0, req1)
VAR
auth0: boolean;
ASSIGN
init(auth0) := 0;
next(auth0) := req0 & !auth1;
VAR
auth1: boolean;
ASSIGN
init(auth1) := 0;
next(auth1) := req1 & !auth0;
--------------------------------------------------
---- The main module -----------------------------
--------------------------------------------------
MODULE main
VAR
U0: User(Ar.auth0); --- User 0
U1: User(Ar.auth1); --- User 1
Ar: Arbiter(U0.req, U1.req); 
```
# Описание модели
В модели есть два пользователя U0 и U1, а также арбитр Ar. Каждый
пользователь может находится в следующих состояниях: NonCritical, Trying
или Critical.
 из NonCritical пользователь может недетерминированно
перейти к Trying;
*из Trying он может перейти в Critical, если это разрешено
арбитром;
*из Critical он может недетерминированно вернуться в
состояние NonCritical.
**Цель арбитра** - гарантировать, что оба пользователя не находятся в
критическом состоянии одновременно 

# Задание
*Смоделируйте поведение программы.
*Формализуйте свойство: "два пользователя не могут находиться
одновременно в критической секции”.
*Зафиксируйте арбитра так, чтобы свойство стало истинным.
*Формализуйте свойство: "если пользователь попытается войти в свою
критическую секцию, он в конечном итоге добьется успеха”.
*Добавьте ограничение справедливости, которое гарантирует, что
пользователь не останется навсегда в критическом сеансе.
*Проверьте, являются ли оба свойства теперь истинными в
расширенной модели, если нет, исправьте модель.
*Измените модель добавив еще одного пользователя.
# Report
Check "Report.docx"
# Author
Pavel Dat