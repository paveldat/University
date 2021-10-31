#include <iostream>
#include <string>

#include <vector>
#include <windows.h>

#include <stdlib.h>
#include <fstream>

#include <iomanip>
#include <cmath>

#include <ctype.h>
#include <stdio.h>

#include <sstream>
#include <exception>


using namespace std;

//class for Errors
class myException
{
    private:
    	string error_;
    	int line_;
	public:
        myException(string error, int line):error_(error), line_(line){}
		string getError(void)
		{
			cout<<error_ << " в "<< line_+1 <<" строке "<<endl;	
		}    
};


class BNF 
{
	public:
		bool isName(string , int);
		bool isBankName(string, int);
		bool isBankNumber(string, int);
		bool isPhoneNumber(string, int);
		bool isBalance(string, int);
		bool isSeparator(string, int);
};

//the main class
class bankCard : public BNF
{
	private:
		string clientName_;
		string bankName_;
		string phoneNumber_;
		string cardNumber_;
		int balanceClient_;
	public:
		bankCard();
		bankCard(const bankCard &c1);
		bankCard(string clientName, string bankName, string phoneNumber,
		string cardNumber, int balanceClient);
		~bankCard();
		
		
		//Setters
		void setClientName(string text, int index);
		void setBankName(string text, int index);
		void setPhoneNumber(string text, int index);
		void setCardNumber(string text, int index);
		void setBalanceClient(string text, int index);
		void setSeparator(string text, int index);
	
	
		//Getters
		string getClientName(void)
		{
			return clientName_;
		}	
		
		string getBankName(void)
		{
			return bankName_;
		}
		
		string getPhoneNumber(void)
		{
			return phoneNumber_;
		}
		
		string getCardNumber(void)
		{
			return cardNumber_;
		}
		
		
		int getBalanceClient(void)
		{
			
			return balanceClient_;	
		}
	
		string getSeparator(void)
		{
			return " ; ";
		}

		friend bool operator==(bankCard c1, bankCard c2);
		friend bool operator>(bankCard c1, bankCard c2);
		bool operator<(bankCard c1);
		bankCard operator++();
		friend int operator++(bankCard, int);
		bankCard operator=(bankCard& c1);
		friend ostream& operator<<(ostream &out, const bankCard &card);
		friend istream& operator>> (istream &s, bankCard &c1);
		bool operator!=(bankCard& c1);
		bankCard operator+=(const bankCard& c2);
		
};




//Проверяем задано ли имя правильно(проверяем, что ФИО написаны с большой буквы, что в них не содержатся посторонние символы и задано только латиницей)
bool BNF::isName(string s, int index)
{
	int pos = index;

	//Проверим фамилию на заглавную букву
	if(s[0] != toupper(s[0]))				
		throw myException("Фамилия не с заглавной буквы ", pos);
		
	//ищем первый пробел и проверяем фамилию на ошибки
	int i1;
	for(int i = 1; i<s.length(); i++)
	{
		if(s[i] == ' ')
		{
			i1 = i;
			break;
		}
		
		if(!(s[i]>='a' && s[i]<='z'))
			throw myException("В фамилии постороний элемент или заглавная буква ", pos);	
	}
	
	//Проверим, что имя написано с большой буквы
	if(s[i1+1] != toupper(s[i1+1]))
		throw myException("Имя написано не с большой буквы ", pos);
	
	
	//Найдем второй пробел и проверим на ошибки имя
	int i2;
	int sp = i1+2;
	for(sp; sp<s.length(); sp++)
	{
		if(s[sp] == ' ')
		{
			i2 = sp;
			break;	
		}
		
		if(!(s[sp]>='a' && s[sp]<='z'))
			throw myException("В имени посторонний элемен или заглавная буква ", pos);	
	}
	
	//Проверим отчество на заглавную букву
	if(s[i2+1] != toupper(s[i2+1]))
		throw myException("Отчество написано не с большой буквы ", pos);
		
	//Проверим отчество на ошибки
	int spc = i2+2;
	for(spc; spc<s.length(); spc++)
	{
		if(!(s[spc] >= 'a' && s[spc] <= 'z'))
			throw myException("В отчестве посторонний элемент или заглавная буква ", pos);	
	}	
	
	return true;	
}


//Проверяем задано ли название банка верно(в одно слово, взято в ковычки, и  не встречаются посторонние символы, кроме "-")
bool BNF::isBankName(string s, int pos)
{
	int n = s.length();
	if(s[0] != '\"' || s[n-1]!='\"')
		throw myException("Название банка не взято в кавычки ", pos);
	if(s[1] != toupper(s[1]))
		throw myException("Название банка написано не с большой буквы ", pos);	
	for(int i = 1; i<s.length()-1; i++)
	{
		if(!(s[i]>='a' && s[i]<='z' || s[i]) == '-')
			throw myException("В названии банка присутсует русский \nсимвол или посторонний элемент ", pos);
	
	}	
	return true;	
}

//Проверим номер телефона(вид +12314567890, кол-во цифр не должно превышать 11 элементов)
bool BNF::isPhoneNumber(string s, int pos)
{
	if(s[0]!='+')
		throw myException("Номер телефона начинается не с '+' ", pos);
	for(int i = 1; i<s.length(); i++)
	{
		if(!isdigit(s[i]))
			throw myException("В номере телефона есть не цифра ", pos);
	}	
	if(s.length() != 12)
		throw myException("Недопустимое кол-во цифр в номере ", pos);
	
	return true;	
}


//Проверяем номер карты(вид 1111 1111 1111 1111)
bool BNF::isBankNumber(string s, int pos)
{
	for(int i = 0; i<4; i++)
		if(!isdigit(s[i]))
			throw myException("В первых 4-х цифрах номера карты не число ", pos);		
			
	for(int i = 5; i<9; i++)
		if(!isdigit(s[i]))
			throw myException("Во вторых 4-х цифрах номера карты не число ", pos);
	
	for(int i = 10; i<14; i++)
		if(!isdigit(s[i]))
			throw myException("В третьих 4-х цифрах номера карты не число ", pos);
			
	for(int i = 15; i<19; i++)
		if(!isdigit(s[i]))
			throw myException("В последних 4-х цифрах номера карты не число ", pos);

	return true;								
}


//Проверяем баланс(вид 123)
bool BNF::isBalance(string s, int pos)
{	
	for(int i = 0; i<s.length(); i++)
	{
		if(!isdigit(s[i]))
			throw myException("Баланс задан не целым положительным числом ", pos);
	}
	return true;
}

//Проверяем разделительный знак(;)
bool BNF::isSeparator(string s, int pos)
{
	if(s[0] != ';')
		throw myException("Не верный разделитель ", pos);
	
	return true;	
}


//Constructors and destructors
bankCard::bankCard(void){}
bankCard::bankCard(string clientName, string bankName, string phoneNumber, string cardNumber, int balanceClient):
	clientName_(clientName), bankName_(bankName), phoneNumber_(phoneNumber), cardNumber_(cardNumber), balanceClient_(balanceClient)
{}
bankCard::bankCard(const bankCard &c1):clientName_(c1.clientName_), bankName_(c1.bankName_), phoneNumber_(c1.phoneNumber_), cardNumber_(c1.cardNumber_), balanceClient_(c1.balanceClient_)
{}
bankCard::~bankCard()
{}


//Setters
void bankCard::setClientName(string text, int index)
{
	if(isName(text,index))
		clientName_ = text;
}

void bankCard::setBankName(string text, int index)
{
	if(isBankName(text, index))
		bankName_ = text;
}

void bankCard::setPhoneNumber(string text, int index)
{
	if(isPhoneNumber(text, index))
		phoneNumber_ = text;
}

void bankCard::setCardNumber(string text, int index)
{
	if(isBankNumber(text, index))
		cardNumber_ = text;
}

void bankCard::setBalanceClient(string text, int index)
{
	
	if(isBalance(text, index))
	{
		//преобразуем строку в int
		istringstream iss(text, istringstream::in);
		int value;
    	iss>>value;
    	balanceClient_ = value;
	}
}

void bankCard::setSeparator(string text, int index)
{
	isSeparator(text, index);
}


//Ovvrides
bool operator==(bankCard c1, bankCard c2)
{
	if(c1.balanceClient_ == c2.balanceClient_ && c1.clientName_ == c2.clientName_ && 
		c1.bankName_ == c2.bankName_ && c1.phoneNumber_ == c2.phoneNumber_ && c1.cardNumber_ == c2.cardNumber_)
		return true;
	return false;	
}

bool operator>(bankCard c1, bankCard c2)
{
	return (c1.balanceClient_ >= c2.balanceClient_);
}

ostream& operator<<(ostream &out, const bankCard &card)
{
	out<<card.clientName_<<" ; "<<card.bankName_<<" ; "<<card.phoneNumber_<<" ; "<<card.cardNumber_<<" ; "<<card.balanceClient_<<endl;
	return out;
}

bankCard bankCard::operator++()
{
	balanceClient_ += 1;
	return *this;	
}

bool bankCard::operator!=(bankCard& c1)
{
	 if(this->clientName_ != c1.clientName_, this->bankName_ != c1.bankName_, 
	    this->phoneNumber_ != c1.phoneNumber_, this->cardNumber_ != c1.cardNumber_,
		this->balanceClient_ != c1.balanceClient_)
			return true;
	else
		return false;							
}

bankCard bankCard::operator=(bankCard& c1)
{
	if(*this != c1)
		return bankCard(this->clientName_ = c1.clientName_, this->bankName_ = c1.bankName_, 
	                	this->phoneNumber_ = c1.phoneNumber_, this->cardNumber_ = c1.cardNumber_,
						this->balanceClient_ = c1.balanceClient_);
	else
		return *this;					
}

int operator++(bankCard c1, int)
{
	c1.balanceClient_+=1;
	return c1.balanceClient_;
}

istream& operator>> (istream &s, bankCard &c1)
{
	cout<<"Enter the name of client: ";
	cin>>c1.clientName_;
	cout<<"\nEnter name of the bank: ";
	cin>>c1.bankName_;
	cout<<"\nEnter telefon number: ";
	cin>>c1.phoneNumber_;
	cout<<"\nEnter card number: ";
	cin>>c1.cardNumber_;
	cout<<"\nEnter balance: ";
	cin>>c1.balanceClient_;
	return s;
}

bool bankCard::operator<(bankCard c1)
{
	return (this->balanceClient_ < c1.balanceClient_);	
}

bankCard bankCard::operator+=(const bankCard& c2)
{
	this->balanceClient_ += c2.balanceClient_;
	return *this;
}


////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////
const int MAX_SIZE = 100;


//Поиск максимального баланса
void putAllBanks(string output[], bankCard arr[], int &index)
{
	int pos = 1;
	bool marker;
	for(int i = 0; i<index; i++)
	{
		marker = true;
		for(int j = 0; j<pos; j++)
		{
			if(arr[i].getBankName() == output[j])
				marker = false;
		}
		if(marker)
		{
			output[pos-1] = arr[i].getBankName();
			pos++;
		}
	}
	index = pos;
}
//Распределение в порядке возрастания баланса
template<typename T>
void insertionSort(bankCard arr[], T n)
{
T i, j;
	bankCard key;
	for (i = 1; i < n; i++)
	{
		key = arr[i];
		j = i - 1;
		while (j >= 0 && arr[j] > key)
		{
			arr[j + 1] = arr[j];
			j = j-1;
		}
		arr[j + 1] = key;
	}
}
//Вывод максимального на экран и сортировка массива
void coutMaxBalance(bankCard allData[], int &index)
{
	cout<<"=============Max balance============="<<endl;
	
	insertionSort(allData, index);
	
	cout<<allData[index-1].getClientName()<<" ; ";
	cout<<allData[index-1].getBankName()<<"  ; ";
	cout<<allData[index-1].getPhoneNumber()<<" ; ";
	cout<<allData[index-1].getCardNumber()<<" ; ";
	cout<<allData[index-1].getBalanceClient()<<endl;	
}

string separator()
{
	return " ; ";
}

int main()
{
	try{
	setlocale(LC_ALL, "RUS");
	string allBanks[MAX_SIZE];
	bankCard allData[MAX_SIZE];
	int index = 0;
	string fileDir;
	
	ifstream cardsFile; //Вход
	ofstream responseFile;  //Вывод
	
	//Чтение из файла
	cardsFile.open("List.txt");
	if(!cardsFile.is_open())
		throw "Файл не найден";
	responseFile.open("Output.txt"); 
	
	
	string name, surname, patronymic, bank, phoneNumber,cardNumber,razd1,razd2,razd3,razd4,card1,card2,card3,card4;
	string balanceClient;
	while(index < MAX_SIZE && cardsFile>>name>>surname>>patronymic>>razd1>>bank>>razd2>>phoneNumber>>razd3>>card1>>card2>>card3>>card4>>razd4>>balanceClient)
	{
		allData[index].setClientName(name + " " + surname + " " + patronymic, index);
		allData[index].setSeparator(razd1, index);
		allData[index].setBankName(bank, index);
		allData[index].setSeparator(razd2, index);
		allData[index].setPhoneNumber(phoneNumber, index);
		allData[index].setSeparator(razd3, index);
		allData[index].setCardNumber(card1+ " " + card2 + " " + card3 + " " + card4, index);
		allData[index].setSeparator(razd4, index);
		allData[index].setBalanceClient(balanceClient, index);
		index++;
	}
	
	//Сортировка и вывод максимального элемента
	coutMaxBalance(allData, index);
	
	//Вывод в файл в таблице
	int i = 0;
	
	//responseFile<<"        Name Client                  Bank Name           Phone            Card                 Balance"<<endl;
	responseFile<<setw(30)<<left<<"==Name Client=="<<separator()<<setw(20)<<"==Bank Name=="<<separator()<<setw(12)<<"==Phone=="<<separator()<<
	              setw(20)<<"==Card=="<<separator()<<setw(8)<<"==Balance=="<<endl;
	responseFile<<"---------------------------------------------------------------------------------------------------------------";              
	responseFile<<setw(33)<<right<<separator()<<setw(23)<<separator()<<setw(15)<<separator()<<setw(23)<<separator()<<setw(11)<<endl;
	while(i<index)
	{
		responseFile<<setw(30)<<left<<allData[i].getClientName()<<separator();
		responseFile<<setw(20)<<allData[i].getBankName()<<separator();
		responseFile<<setw(12)<<allData[i].getPhoneNumber()<<separator();
		responseFile<<setw(20)<<allData[i].getCardNumber()<<separator();
		responseFile<<setw(8)<<allData[i].getBalanceClient()<<endl;
		i++;
	}
	
	
	//Вывод в тот же файл названия всех банков
	responseFile << "\n";
	responseFile << "\n";
	responseFile << "--------------ALL BANKS--------------\n";
	
	i = 0;
	putAllBanks(allBanks, allData, index);
	while (i < index ) {
		responseFile << allBanks[i] << "\n";
		i++;
	}
	return 0;
	
}

catch(myException& ex)
{
	cerr<<ex.getError()<<endl;
}
catch(const char* errorString)
{
	cerr<<errorString<<endl;
}
}
