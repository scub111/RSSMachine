////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                          Project : Smoky1                                  //
//                              161001                                        //
////////////////////////////////////////////////////////////////////////////////


#ifndef __SMOKY_COMMON_H
#define __SMOKY_COMMON_H


#define DISABLE_INTERRUPT() __disable_interrupt()
#define ENABLE_INTERRUPT()  __enable_interrupt()

/*
Распределение адресного пространства.
0x00 - 0x7F - ячейки.
0x80 - 0x8F - пульт и пр.
0x80 - пульт.
0xC0 - диспетчер, процессор среднего уровня.
*/

#define ADDR_0        ((uint8_t)0)
#define ADDR_1        ((uint8_t)1)
#define ADDR_2        ((uint8_t)2)
#define ADDR_3        ((uint8_t)3)
#define ADDR_4        ((uint8_t)4)

#define ADDR_COMMON   ADDR_0

#define ADDR_CELL_MAX   0x4A//74
#define ADDR_PULT       0x80
#define ADDR_DISPATCHER 0xC0

/*
В описании информации состояния "1" всегда соответствует наличию особого состояния (события).
"0" соответствует отсутствию особого состояния (события).
*/

/*
Описание слова состояния контроллера механизма выдачи (КМВ или ячейка).
*/
#define ST_CELL_MOTOR         ((uint16_t)1 << 0)  // Состояние мотора. 1 - мотор включен/работает. 0 - выключен.
#define ST_CELL_SENS_MOTOR    ((uint16_t)1 << 1)  // Датчик лопатки. 1 - находится в месте парковки. 0 - не в месте парковки.
#define ST_CELL_SENS_NAL      ((uint16_t)1 << 2)  // Датчик наличия товара. 1 - товар есть. 0 - товара нет.
#define ST_CELL_ADDR          ((uint16_t)1 << 3)  // Наличие адреса. 1 - адреса нет. 0 - адрес есть.
#define ST_CELL_SENS_HI       ((uint16_t)1 << 4)  // Датчик уровня товара HIGH. 1 - количество товара более максимального. 0 - количество товара менее максимального.
#define ST_CELL_SERVICE       ((uint16_t)1 << 5)  // Сервисный бит. 1 - . 0 - . 160819 !!! Только для отладки самой ЯЧЕЙКИ. НЕ ДЛЯ LINUX. 1 - нет связи. 0 - есть связь.
#define ST_CELL_MOTOR_ER      ((uint16_t)1 << 6)  // Неисправность механизма выдачи (мотор, транспотер). 1 - механизм неисправен. 0 - механизм исправен.
#define ST_CELL_SENS_NAL_LEV  ((uint16_t)1 << 7)  // Режим проверки состояния датчиков. 1 - выполняется проверка состояния датчиков. 0 - проверка не выполняется.
#define ST_CELL_IGNORE        ((uint16_t)1 << 8)  // Режим игнорирования команд. 1 - команды игнорируются. 0 - команды выполняются.
#define ST_CELL_CALIBR        ((uint16_t)1 << 9)  // Наличие калибровочных параметров. 1 - устройство не откалибровано и не может работать. 0 - устройство откалибровано и может работать.
#define ST_CELL_CALIBR_GO     ((uint16_t)1 << 10) // Состояние калибровки. 1 - калибровка выполняется. 0 - калибровка не выполняется.
#define ST_CELL_REPROG        ((uint16_t)1 << 11) // Получена команда репрограммирования. 1 - процессор в BOOTLOADER-е. 0 - нет.
#define ST_CELL_TEST_GO       ((uint16_t)1 << 12) // Проверка устройства на функционирование. 1 - выполняется. 0 - не выполняется.
//
//
#define ST_CELL_LINK          ((uint16_t)1 << 15) // Только для отладки самой ЯЧЕЙКИ. НЕ ДЛЯ LINUX. 1 - нет связи. 0 - есть связь.

/*******************************************************************************
                  Описание слова состояния пульта кассира.
*******************************************************************************/

#define PULT_BEEP_MAX 10// Максимальное количество бипов по 0,1 сек через 0,1 сек.

// Коды светодиодов пульта
#define PULT_LED_VIKL         ((uint8_t)1 << 0)
#define PULT_LED_RAZRESHIT    ((uint8_t)1 << 1)
#define PULT_LED_ZAPRETIT     ((uint8_t)1 << 2)
#define PULT_LED_KEY          ((uint8_t)1 << 3)
#define PULT_LED_TOVAR        ((uint8_t)1 << 4)

#define ST_PULT_LED_VIKL      ((uint16_t)PULT_LED_VIKL) //0 Состояние светодиода ВЫКЛ. 1 - с/д включен. 0 - с/д выключен.
#define ST_PULT_LED_RAZRESHIT ((uint16_t)PULT_LED_RAZRESHIT) //1 Состояние светодиода РАЗРЕШИТЬ. 1 - с/д включен. 0 - с/д выключен.
#define ST_PULT_LED_ZAPRETIT  ((uint16_t)PULT_LED_ZAPRETIT) //2 Состояние светодиода ЗАПРЕТИТЬ. 1 - с/д включен. 0 - с/д выключен.
#define ST_PULT_LED_KEY       ((uint16_t)PULT_LED_KEY) //3 Состояние светодиода КЛЮЧ. 1 - с/д включен. 0 - с/д выключен.
#define ST_PULT_LED_TOVAR     ((uint16_t)PULT_LED_TOVAR) //4 Состояние светодиода ТОВАРНЫЙ ЗАПАС. 1 - с/д включен. 0 - с/д выключен.#define ST_PULT_CFG           ((uint16_t)1 << 5) // Состояние конфигурации ключей. 1 - конфигурация отсутствует. 0 - устройство сконфигурировано.
#define ST_PULT_CFG           ((uint16_t)1 << 5)  //5 Состояние конфигурации ключей. 1 - конфигурация отсутствует. 0 - устройство сконфигурировано.
#define ST_PULT_MEMORY        ((uint16_t)1 << 6)  //6 Состояние энергонезависимой  памяти. 1 - неисправность памяти при записи. 0 - память исправна.
#define ST_PULT_BUT_VIKL      ((uint16_t)1 << 7)  //7 Состояние кнопки ВЫКЛ. 1 - кн. нажата. 0 - кн. не нажата.
#define ST_PULT_BUT_RAZRESHIT ((uint16_t)1 << 8)  //0 Состояние кнопки РАЗРЕШИТЬ. 1 - кн. нажата. 0 - кн. не нажата.
#define ST_PULT_BUT_ZAPRETIT  ((uint16_t)1 << 9)  //1 Состояние кнопки ЗАПРЕТИТЬ. 1 - кн. нажата. 0 - кн. не нажата.
#define ST_PULT_USER_KEY      ((uint16_t)1 << 10) //2 Признак считывания ПОЛЬЗОВАТЕЛЬСКОГО КЛЮЧА. 1 - считан ПОЛЬЗОВАТЕЛЬСКИЙ КЛЮЧ. 0 - не считан.
#define ST_PULT_UNKNOW_KEY    ((uint16_t)1 << 11) //3 Признак считывания НЕИЗВЕСТНОГО КЛЮЧА. 1 - считан НЕИЗВЕСТНЫЙ КЛЮЧ. 0 - не считан.
#define ST_PULT_KEY_LOCK      ((uint16_t)1 << 12) //4 Признак запрета считывания ключей. 1 - ключи не считываются. Сбрасывется по команде Cmd_Pult_Key_Free.
#define ST_PULT_KEY_CYCLE     ((uint16_t)1 << 13) //5 Признак циклического считывания ключей. 1 - цклическое чтение ключей. Устанавливается по команде Cmd_Pult_Key_Read_Cycle. Сбрасывется по команде Cmd_Pult_Key_Free.
#define ST_PULT_PWRON         ((uint16_t)1 << 14) //6 Команда ДИСПЕТЧЕРУ включить ПК.
#define ST_PULT_BEEP          ((uint16_t)1 << 15) //7 Состояние БИПЕРА. 1 - пищит, 0 - нет.
/*
Описание uint16_t состояния диспетчера.
*/
#define ST_DISP_LIGHT1        ((uint32_t)1 << 0)  // Состояние подсветки1. 1 - включена. 0 - выключена.
#define ST_DISP_LIGHT2        ((uint32_t)1 << 1)  // Состояние подсветки2. 1 - включена. 0 - выключена.
#define ST_DISP_TR_H          ((uint32_t)1 << 2)  // Состояние горизонтального транспортера. 1 - мотор включен/работает. 0 - выключен.
#define ST_DISP_TR_V          ((uint32_t)1 << 3)  // Состояние горизонтального транспортера. 1 - мотор включен/работает. 0 - выключен.

#define ST_DISP_PRO_LED       ((uint32_t)1 << 4)  // Состояние светодиода датчика пролета. 1 - включен. 0 - выключен.
#define ST_DISP_PRO_PHOTO     ((uint32_t)1 << 5)  // Состояние фото-датчика пролета. 1 - засвечен. 0 - не засвечен.
#define ST_DISP_PRO_CONTROL   ((uint32_t)1 << 6)  // Состояние датчика пролета. 1 - сканируется. 0 - нет.
#define ST_DISP_PROLET        ((uint32_t)1 << 7)  // Состояние датчика пролета. 1 - пролетел. 0 - нет. ЭТОТ БИТ СБРАСЫВАЕТСЯ ПО КОМАНДЕ Cmd_Prolet_Control с нулевым параметром.

#define ST_DISP_DOOR1         ((uint32_t)1 << 8)  // Состояние двери1. 1 - открыта. 0 - закрыта.
#define ST_DISP_DOOR2         ((uint32_t)1 << 9)  // Состояние двери2. 1 - открыта. 0 - закрыта.
#define ST_DISP_BEEP          ((uint32_t)1 << 10) // Состояние бипера/пищалки. 1 - пищит. 0 - не пищит.
#define ST_DISP_CELL          ((uint32_t)1 << 11) // Состояние питания, инициализации ЯЧЕЕК. 1 - питание вкл. 0 - нет.

#define ST_DISP_PULT          ((uint32_t)1 << 12) // Состояние питания, инициализации ПК. 1 - питание вкл. 0 - нет.
#define ST_DISP_TR_H_START    ((uint32_t)1 << 13) // Состояние старта гор. трансп. 1 - при медленном старте пока тр. не стартует, 0 - тр. стартовал.
#define ST_DISP_LINK          ((uint32_t)1 << 15) // Только для отладки. НЕ ДЛЯ LINUX!!! 1 - нет связи. 0 - есть связь.
#define ST_DISP_PWR_LEFT      ((uint32_t)1 << 16) // Состояние питания ЯЧЕЕК левой двери. 1 - питание вкл. 0 - нет.

#define ST_DISP_PWR_RIGHT     ((uint32_t)1 << 17) // Состояние питания ЯЧЕЕК правой двери. 1 - питание вкл. 0 - нет.
#define ST_DISP_PWR_PANEL     ((uint32_t)1 << 18) // Состояние питания ЯЧЕЕК задней панели. 1 - питание вкл. 0 - нет.
#define ST_DISP_PRODAJA       ((uint32_t)1 << 19) // Состояние Продажи. 1 - выполняется. 0 - нет.
#define ST_DISP_PRODAJA_LINK  ((uint32_t)1 << 20) // Состояние Продажи. 1 - нет связи с ЯЧЕЙКОЙ. 0 - связь с ЯЧЕЙКОЙ есть. 1 - Продажа прекращается. Бит сбрасывается по команде...

#define ST_DISP_PRODAJA_TOVAR ((uint32_t)1 << 21) // Состояние Продажи. 1 - в ЯЧЕЙКЕ нет товара. 0 - в ЯЧЕЙКЕ товар есть. 1 - Продажа прекращается. Бит сбрасывается по команде...
#define ST_DISP_PRODAJA_CELL  ((uint32_t)1 << 22) // Состояние Продажи. 1 - ЯЧЕЙКА не может выдать товар. 0 - ЯЧЕЙКА может выдать товар. 1 - Продажа прекращается. Бит сбрасывается по команде...

/*
Перечень команд.
*/
#define Cmd_Nop               0x00  // Пустая команда. НЕ ДЛЯ LINUX!!!
#define Cmd_Link              0x01  // Проверка связи.
#define Cmd_Status            0x02  // Запрос состояния устройства, включая состояние датчиков.
#define Cmd_Telemetry         0x03  // Запрос телеметрии.
#define Cmd_Cell_Motor        0x04  // Выдать 1 еденицу товара.
#define Cmd_Cell_Sens_Control 0x05  // Выполнить проверку состояния датчиков. Запрос состояния по Cmd_Status.
#define Cmd_Cfg_Read          0x06  // Запрос конфигурации.
#define Cmd_Cfg_Write         0x07  // Запись конфигурации.

#define Cmd_Dev_Reset         0x08  // Сброс устройства.
#define Cmd_Ignore_Begin      0x09  // Начать игнорировать команды. При адресе 0, игнорируют все устройства.При конкретном адресе, игнорирует только адресуемое устройство.
#define Cmd_Ignore_End        0x0A  // Закончить игнорировать команды.
#define Cmd_Cfg_Write_0       0x0B  // Запись конфигурации только для адреса 0.

#define Cmd_Hardware_Ver      0x0C  // Запрос аппаратной версии.???
#define Cmd_Firmware_Ver      0x0D  // Запрос программной версии.???
#define Cmd_Dev_Info          0x0E  // Запрос информации об устройстве.???
#define Cmd_Id_Request        0x0F  // Запрос информации об устройстве.???

#define Cmd_Light1            0x10  // Упр. подсветкой1. 1-вкл, 0-выкл.
#define Cmd_Light2            0x11  // Упр. подсветкой2. 1-вкл, 0-выкл.
#define Cmd_Beep              0x12  // Упр. пищалкой. 1-пропищать, 1 писк 100 мс.
#define Cmd_Trans_Hor         0x13  // Упр. горизонтальным транспортером,Быстрый старт. 1-вкл, 0-выкл.
#define Cmd_Trans_Ver         0x14  // Упр. вертикальным транспортером. 1-вкл, 0-выкл.
#define Cmd_Prolet_Led        0x15  // Упр. светодиодом датчика пролета. 1-вкл, 0-выкл.
#define Cmd_Prolet_Photo      0x16  // Запрос состояния фото-датчика пролета. В ответе 1- засвечен, 0 - не засвечен.
#define Cmd_Prolet_Control    0x17  // Упр. сканированием датчика пролета. 1 - сканировать, включает с/диод.
                                    // 0 - нет, выключает с/диод.
#define Cmd_Trans_Hor_Slow    0x18  // Упр. горизонтальным транспортером, Медленный старт. 1-вкл, 0-выкл.

#define Cmd_Pwr_Off           0x20  // Выключение устройства: линуксовая плата, монитор, ячейки. Команда ДИСПЕТЧЕРУ на выключение питания. ДИСПЕТЧЕР и ПК продолжают работать.
#define Cmd_Cell_Restart      0x21  // Перезапустить все ЯЧЕЙКИ. Время перезапуска, с учетом автоинициализации ЯЧЕЕК, 1 секунда.
#define Cmd_Pult_Restart      0x22  // Перезапустить ПУЛЬТ КАССИРА. Время перезапуска 1 секунда.
#define Cmd_Section_Pwr       0x23  // Управление питанием секций&
        #define PWR_DOOR_LEFT     ((uint8_t)1 << 0) //Левая дверь U1. 1 - вкл, 0 - выкл.
        #define PWR_DOOR_RIGHT    ((uint8_t)1 << 1) //Правая дверь U5. 1 - вкл, 0 - выкл.
        #define PWR_PANEL_REAR    ((uint8_t)1 << 2) //Задняя панель U4. 1 - вкл, 0 - выкл.
        #define PWR_PULT          ((uint8_t)1 << 3) //Пульт кассира. 1 - вкл, 0 - выкл.

#define Cmd_Pult_Key_Free     0x25  // Завершить повторяющуюся передачу указанного считанного ключа.
#define Cmd_Pult_Key_Lock     0x26  // Завершить повторяющуюся передачу указанного считанного ключа.
#define Cmd_Pult_Beep         0x27  // Пищать N раз. N указан параметром.
#define Cmd_Pult_Led          0x28  // Управление с/диодами пульта. См. параметр.
#define Cmd_Pult_Beep_Led     0x29  // Управление бипером и с/диодами пульта. См. параметр.

#define Cmd_Status_Ex         0x45  // Запрос расширенного состояния устройства.
#define Cmd_Prodaja           0x46  // Продать товар.

typedef struct {
  uint8_t Addr;
  uint8_t Quant;
  uint8_t Trans_Hor_Start_Type;//Cmd_Trans_Hor, Cmd_Trans_Hor_Slow
  uint8_t Par;
} Prodaja_Str_t;
#define TOVAR_QUANT_MAX   10  //Максимальное количество пачек за 1 продажу.

typedef struct{
  uint8_t  Addr;          //Адрес ЯЧЕЙКИ из которой выдается товар.
  uint8_t  Quant;         //Количество выданного товара.
  uint32_t Disp_StatusEx; //Расширенный статус ДИСПЕТЧЕРА.
  uint16_t Cell_Status;   //Статус ЯЧЕЙКИ.
}Prodaja_Telemetry_Str_t; //8Bt


/*
  1 бт. параметров.
  "1" - включить питание.
  "0" - включить питание.
  Соответствие битов в байт:
  ((uint8_t)1 << 0) // 1 секция. Левая дверь.
  ((uint8_t)1 << 1) // 2 секция. Правая дверь.
  ((uint8_t)1 << 2) // 3 секция. Стенка, верхний и нижний ряды.
  //((uint8_t)1 << 3) // 4 секция. Пульт.
  */
      
/*
Коды результата обработки команд
*/
#define RES_OK            0 // В команде нет ошибок
#define RES_CMD_ERROR     1 // Недостоверный код команды
#define RES_DATA_ERROR    2 // Недостоверные данные-параметры в команде
#define RES_HW_ERROR      3 // Команда не может быть выполнена из-за аппаратной неисправности
#define RES_OPTION_ERROR  4 // Команда не может быть выполнена из-за программных настроек
#define RES_CMD_OTHER     5 // Получен ответ не на отправленную (другую) команду - для мастера
#define RES_DATA          6 // Есть данные
#define RES_BUSY          7 // Команда в настоящее время не может быть выполнена, т.к. требуемая периферия занята.


////////////////////////////////////////////////////////////////////////////////
/*
Информация об устройстве
*/

typedef struct{
  unsigned short IdShort; // Цифровой идентификатор устройства 510, 520, 550
  unsigned short HW_Ver;  // Версия платы
  unsigned long  FW_Ver;  // Версия/дата прошивки. Напр. 16081601. ггммддNN. NN на случай не одной (нескольких) прошивок в день.
  char IdLong[16];        // Полный идентификатор устройства RSS16000.510 и т.д.
  char Manufacturer[10];
}DevInfo_Str_t;//34

////////////////////////////////////////////////////////////////////////////////
// ЯЧЕЙКА

#define CELL_CFG_SIZE 8 //Размер кратен 4 байтам
/* Конфигурация ячейки содержит только адрес ячейки */
#pragma pack(1)
typedef union{
  struct Cfg_Str_t{
    uint8_t Addr;                 // Адрес ячейки      1
    uint8_t Par[CELL_CFG_SIZE-2]; // Про-запас         6
    uint8_t Cs;                   // Контрольная сумма 1
  }Cfg_Str;//8
  uint8_t Cfg_Data[CELL_CFG_SIZE];// 8
  uint32_t Cfg_DW[CELL_CFG_SIZE/4];//8
}Cell_Cfg_Union_t;//8
#pragma pack()

/*
    16.07.2016
*/
// НЕ ДЛЯ LINUX
//#define CELL_CALIBRCFG_SIZE 8 //Размер кратен 4 байтам
#define CELL_CALIBR_PAR     4 //4 параметра по 4 бт
/* Конфигурация калибровки ячейки содержит 4 параметра и 4бт CS */
typedef union{
  struct CfgCalibr_Str_t{
    uint32_t K[CELL_CALIBR_PAR];// Параметры        16
    uint32_t Cs;                // Контрольная сумма 4
  }CfgCalibr_Str;//20
  uint32_t Cfg_DW[CELL_CALIBR_PAR + 1];//20
}Cell_CfgCalibr_Union_t;//20

typedef union {
  struct {
    Cell_Cfg_Union_t Cell_Cfg_Uni;            // 8
    Cell_CfgCalibr_Union_t Cell_CfgCalibr_Uni;//20
    uint32_t Par1;                            // 4
    uint32_t Par2;                            // 4
  }CfgStr;//36
  uint32_t Cfg_uint32_t[sizeof(Cell_Cfg_Union_t)/4 + sizeof(Cell_CfgCalibr_Union_t)/4 + 2];//(2+5+2)*4=36
}CellConfig_Uni_t;

////////////////////////////////////////////////////////////////////////////////
// ПУЛЬТ КАССИРА

// Key
#define KEY_QUANT 6

#pragma pack(1)
typedef union{
  struct{
    uint8_t Type;
    uint8_t SerNum[6];
    uint8_t CRC_Key;
  }Key_Str;
  uint8_t Key_Buf[sizeof(Key_Str)];
}Key_Union_t;//8
#pragma pack()

#pragma pack(1)
typedef struct{
  Key_Union_t Key_Array[KEY_QUANT];
  uint8_t     Par[sizeof(Key_Union_t)];//FOR LINUX NOT USED!!! ТОЛЬКО ДЛЯ ПЛАТЫ ПУЛЬТА.
}Key_Cfg_Str_t;//8*6+8=56
#pragma pack()

#define KEY_CFG_CS  Key_Cfg_Str.Par[7]

typedef struct{
  uint16_t Status;
  Key_Union_t Key;
}Pult_Telemetry_Str_t;






#if 0


\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
ОПИСАНИЕ КОМАНДНОГО ПРОТОКОЛА ДЛЯ ПРОГРАММИСТА LINUX.

Порядок обмена данными между платой LINUX (ПЛ) и платой среднего уровня (ДИСПЕТЧЕР).
Обмен данными производится по интерфейсу USB2.0. ДИСПЕТЧЕР эмулирует виртуальный COM-Port.
Инициатор обмена всегда ПЛ.
Один обмен данными (транзакция) включают передачу команды от ПЛ к ДИСПЕТЧЕРУ и ответа на команду от ДИСПЕТЧЕРА к ПЛ.
Время между получением команды, адресуемой ДИСПЕТЧЕРУ, и выдачей ответа не превышает 10 миллисекунд (мс).
ПЛ обязательно проверяет код команды в полученном ответе, если код команды не совпадает, то ПЛ может повторить команду.
Если код команды совпадает, но Код результата обработки команды не RES_OK, то команда не выполнена по причине, указанной Кодом результата.
ПЛ может проанализировать причину и по возможности устранить.

Описание формата команд.
| ADDR | Cmd | Data(n) | Cs |
0      1     2         3    Всего 3+n байт
ADDR - адрес устройства. 1 бт.
Cmd - код команды. 1 бт.
Data(n) - данные передаваемые в устройство. n бт.
Cs - контрольная сумма. 1 бт.
Функция вычисления контрольной суммы:
uint8_t Cs_Calc(uint8_t *buf, uint16_t n)
{
uint16_t a;

uint8_t cs = 0;

  for(a = 0; a < n ; a++) cs += *buf++;
  cs++;
  cs = ~cs;
  return( cs );
}


Описание формата ответа.
| ADDR | Cmd | Code_Res | Data(n) | Cs |
0      1     2     3         4    Всего 4+n байт
ADDR - адрес устройства. 1 байт.
Cmd - код полученной команды. 1 бт.
Code_Res - Код результата обработки команды . 1 бт.
Data(n) - данные передаваемые в П-LIN. n бт.
Cs - контрольная сумма. 1 бт.
Функция вычисления контрольной суммы см. выше.

Примеры команд КМВ.
//------------------------------------------------------------------------------
Пример команды Cmd_Link Проверка связи:
01 01 FC
0  1  2  = 3bt
ADDR - Адрес устройства                   0x01  - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Link                0x01  - 1 uint8_t, unsigned char (uint8_t)
Data - Данные, в этой команде отсутстуют        - 0 uint8_t,
Cs - Контрольная сумма                    0xFC  - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Link:
01 01 00 FC
0  1  2  3 = 4bt
ADDR - Адрес устройства                   0x01 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Link                0x01 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата                        0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Данные, в этой команде отсутстуют       - 0 uint8_t,
Cs - Контрольная сумма                    0xFC - 1 uint8_t, unsigned char (uint8_t) 
//------------------------------------------------------------------------------
Пример команды Cmd_Status Запрос состояния:
01 02 FB
0  1  2  = 3bt
ADDR - Адрес устройства                   0x01 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Status              0x02 - 1 uint8_t, unsigned char (uint8_t)
Data - Данные, в этой команде отсутстуют       - 0 uint8_t,
Cs - Контрольная сумма                    0xFB - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Status:
01 02 00 12 00 00 E9
0  1  2  3  4  5  = 5bt
ADDR - Адрес устройства                   0x01 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Status              0x02 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата                        0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Status                           0x0012 - 2 uint8_t, uint16_t в интеловском формате
       Status bt0                         0x12
       0x12 = ((uint8_t)1 << 1) | ((uint8_t)1 << 4)
            = ST_CELL_SENS_MOTOR | ST_CELL_SENS_HI
       "1" - Датчик лопатки в месте парковки, количество товара более максимального.
       "0" - Мотор выключен, товар есть, устройство сконфигурировано, механизм исправен, проверка датчиков не выполняется.
       Status bt1                         0x00
Cs - Контрольная сумма                    0xE9 - 1 uint8_t, unsigned char (uint8_t) 
//------------------------------------------------------------------------------
Пример команды Cmd_Cell_Motor Выдать единицу товара:
01 04 F9
0  1  2  = 3bt
ADDR - Адрес устройства                   0x01  - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Cell_Motor          0x04  - 1 uint8_t, unsigned char (uint8_t)
Data - Данные, в этой команде отсутстуют        - 0 uint8_t,
Cs - Контрольная сумма                    0xF9  - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Cell_Motor:
01 04 00 F9
0  1  2  3 = 4bt
ADDR - Адрес устройства                   0x01 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Cell_Motor          0x04 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата                        0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Данные, в этой команде отсутстуют       - 0 uint8_t,
Cs - Контрольная сумма                    0xF9 - 1 uint8_t, unsigned char (uint8_t) 

При неисправности механизма выдачи:
01 04 03 F6
0  1  2  3 = 4bt
ADDR - Адрес устройства                   0x01 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Cell_Motor               0x01 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата RES_HW_ERROR           0x03 - 1 uint8_t, unsigned char (uint8_t)
Data - Данные, в этой команде отсутстуют       - 0 uint8_t,
Cs - Контрольная сумма                    0xF6 - 1 uint8_t, unsigned char (uint8_t) 
//------------------------------------------------------------------------------
Пример команды Cmd_Cell_Sens_Control Выполнить проверку состояния датчиков:
01 05 F8
0  1  2  = 3bt
ADDR - Адрес устройства                   0x01  - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Cell_Sens_Control        0x01  - 1 uint8_t, unsigned char (uint8_t)
Data - Данные, в этой команде отсутстуют        - 0 uint8_t,
Cs - Контрольная сумма                    0xF8  - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Cell_Sens_Control:
01 05 00 F8
0  1  2  3 = 4bt
ADDR - Адрес устройства                   0x01 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Cell_Sens_Control        0x01 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата                        0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Данные, в этой команде отсутстуют       - 0 uint8_t,
Cs - Контрольная сумма                    0xF8 - 1 uint8_t, unsigned char (uint8_t) 
Время выполнения команды (сканирования/проверки датчиков 25-30 мс).
Состояние датчиков проверять командой Cmd_Status.
//------------------------------------------------------------------------------
Пример команды Cmd_Cfg_Read Запрос конфигурации:
Конфигурационная информация описана в Cell_Cfg_Union_t, занимает 8 байт.
В конфигурации необходим только адрес ячейки и контрольная сумма.
Остальные байты про-запас.
01 06 F7
0  1  2  = 3bt
ADDR - Адрес устройства                   0x01 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Cfg_Read            0x06 - 1 uint8_t, unsigned char (uint8_t)
Data - Данные, в этой команде отсутстуют       - 0 uint8_t,
Cs - Контрольная сумма                    0xF7 - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Cfg_Read:
01 06 00 01 00 00 00 00 00 00 ED 09
0  1  2  3  4  5  6  7  8  9  10 11 = 12bt
ADDR - Адрес устройства                   0x01 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Cfg_Read            0x06 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата                        0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - 0x01 0x00 0x00 0x00 0x00 0x00 0x00 0xED - 8 uint8_t, uint8_t
       0x01 - адрес ячейки, 0xED - Cs
Cs - Контрольная сумма                    0x09 - 1 uint8_t, unsigned char (uint8_t) 
//------------------------------------------------------------------------------
Пример команды Cmd_Cfg_Write Запись конфигурации:
Конфигурационная информация описана в Cell_Cfg_Union_t, занимает 8 байт.
В конфигурации необходим только адрес ячейки и контрольная сумма.
Остальные байты про-запас.
00 07 01 00 00 00 00 00 00 FD F9
0  1  2  3  4  5  6  7  8  9  10 = 11t
ADDR - Адрес устройства                   0x00 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Cfg_Write           0x07 - 1 uint8_t, unsigned char (uint8_t)
Data - 0x01 0x00 0x00 0x00 0x00 0x00 0x00 0xFD - 8 uint8_t,
        Присвоить ячейке адрес 0x01, 0xFD - Cs
Cs - Контрольная сумма                    0xF9 - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Cfg_Write:
01 07 00 F6
0  1  2  3  = 4bt
ADDR - Адрес устройства                   0x01 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Cfg_Write           0x07 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата                        0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Данные, в этой команде отсутстуют       - 0 uint8_t,
Cs - Контрольная сумма                    0xF6 - 1 uint8_t, unsigned char (uint8_t) 

При неисправности флеш-памяти (ошибка записи в память):
01 07 03 F3
0  1  2  3  = 4bt
ADDR - Адрес устройства                   0x01 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Cfg_Write           0x07 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата RES_HW_ERROR           0x03 - 1 uint8_t, unsigned char (uint8_t)
Data - Данные, в этой команде отсутстуют       - 0 uint8_t,
Cs - Контрольная сумма                    0xF3 - 1 uint8_t, unsigned char (uint8_t) 
//------------------------------------------------------------------------------
Пример команды Cmd_Dev_Reset Сброс устройства:
01 08 F5
0  1  2  = 3bt
ADDR - Адрес устройства                   0x01  - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Dev_Reset           0x08  - 1 uint8_t, unsigned char (uint8_t)
Data - Данные, в этой команде отсутстуют        - 0 uint8_t,
Cs - Контрольная сумма                    0xF5  - 1 uint8_t, unsigned char (uint8_t) 

Ответа на Cmd_Dev_Reset нет.
Ячейка сбрасывается/перезапускается.
Время на перезапуск около 100 мс.
//------------------------------------------------------------------------------

ОСТАЛЬНЫЕ КОМАНДЫ С ЯЧЕЙКАМИ НЕ РАБОТАЮТ.

Пример ответа ячейки на команды неработающие с ячейками:
01 03 01 F9
0  1  2  3  = 4bt
ADDR - Адрес устройства                   0x01 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Telemetry           0x03 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата RES_CMD_ERROR          0x01 - 1 uint8_t, unsigned char (uint8_t)
Data - Данные, в этой команде отсутстуют       - 0 uint8_t,
Cs - Контрольная сумма                    0xF9 - 1 uint8_t, unsigned char (uint8_t) 
//------------------------------------------------------------------------------
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////


КОМАНДЫ РАБОТЫ С ПУЛЬТОМ КАССИРА.



//------------------------------------------------------------------------------
Пример команды Cmd_Status 0x02:
80 02 7C
0  1  2  = 3bt
ADDR - Адрес устройства                   0x80 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Status              0x02 - 1 uint8_t, unsigned char (uint8_t)
Cs - Контрольная сумма                    0x7C - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Status:
80 02 00 20 40 1C
0  1  2  3  4  5  = 6bt
ADDR - Адрес устройства                   0x80 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Status              0x02 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата                        0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Status - 20 40 в интеловском формате = 0x4020 - 1 uint16_t
                                            (uint16_t)1 << 5  - ST_PULT_CFG
                                            (uint16_t)1 << 14 - ST_PULT_PWRON
Cs - Контрольная сумма                    0x1C - 1 uint8_t, unsigned char (uint8_t) 
//------------------------------------------------------------------------------
Пример команды Cmd_Telemetry 0x03:
C0 03 3B
0  1  2  = 3bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Pult_Key_Read       0x03 - 1 uint8_t, unsigned char (uint8_t)
Cs - Контрольная сумма                    0x3B - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Telemetry:
C0 03 00 28 55 01 16 C0 D5 17 00 00 68 3E
0  1  2  3  4  5  6  7  8  9  10 11 12 13 = 14bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Telemetry           0x03 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата                        0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Status - 28 55 в интеловском формате = 0x5528 - 1 uint16_t
                                            (uint16_t)1 << 3  - ST_PULT_LED_KEY
                                            (uint16_t)1 << 5  - ST_PULT_CFG
                                            (uint16_t)1 << 10 - ST_PULT_USER_KEY
                                            (uint16_t)1 << 12 - ST_PULT_KEY_LOCK
                                            (uint16_t)1 << 14 - ST_PULT_PWRON
       Ключ -   01 16 C0 D5 17 00 00 68 - 8 uint8_t,
Cs - Контрольная сумма                    0x3E - 1 uint8_t, unsigned char (uint8_t) 
//------------------------------------------------------------------------------
Пример команды Cmd_Cfg_Read 0x06:
C0 06 38
0  1  2  = 3bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Pult_Key_Read       0x06 - 1 uint8_t, unsigned char (uint8_t)
Cs - Контрольная сумма                    0x38 - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Cfg_Read при отсутствии конфигурационных данных:
C0 06 02 36
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Telemetry           0x03 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата       - RES_DATA_ERROR 0x02 - 1 uint8_t, unsigned char (uint8_t)
Cs - Контрольная сумма                    0x36 - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Cfg_Read при наличии конфигурационных данных:
C0 06 00 01 16 C0 D5 17 00 00 68 00 00 00 00 00 00 00 00 FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF 2D
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Cfg_Read            0x06 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата       - RES_OKEY       0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Таблица кодов ключей Key_Cfg_Str_t;//8*6+8=56bt
                                          01 16 C0 D5 17 00 00 68 - 8 uint8_t,
                                          00 00 00 00 00 00 00 00 - 8 uint8_t,
                                          FF FF FF FF FF FF FF FF - 8 uint8_t,
                                          FF FF FF FF FF FF FF FF - 8 uint8_t,
                                          FF FF FF FF FF FF FF FF - 8 uint8_t,
                                          FF FF FF FF FF FF FF FF - 8 uint8_t,
Cs - Контрольная сумма                    0x2D - 1 uint8_t, unsigned char (uint8_t)
//------------------------------------------------------------------------------
Пример команды Cmd_Cfg_Write 0x07:
C0 07 01 16 C0 D5 17 00 00 68 00 00 00 00 00 00 00 00 FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF 2D
0  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 = 51bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Cfg_Write           0x07 - 1 uint8_t, unsigned char (uint8_t)
Data - 6 ключей по 8 байт = 48 байт.
Cs - Контрольная сумма                    0x2D - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Cfg_Write при ошибке записи в энергонезависимую память:
C0 07 03 34
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Cfg_Write           0x07 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата       - RES_HW_ERROR   0x03 - 1 uint8_t, unsigned char (uint8_t)
Cs - Контрольная сумма                    0x34 - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Cfg_Write при наличии конфигурационных данных:
C0 07 00 01 16 C0 D5 17 00 00 68 00 00 00 00 00 00 00 00 FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF 2C
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Cfg_Write           0x07 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата       - RES_OKEY       0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Таблица кодов ключей Key_Cfg_Str_t;//8*6+8=56bt
                                          01 16 C0 D5 17 00 00 68 - 8 uint8_t,
                                          00 00 00 00 00 00 00 00 - 8 uint8_t,
                                          FF FF FF FF FF FF FF FF - 8 uint8_t,
                                          FF FF FF FF FF FF FF FF - 8 uint8_t,
                                          FF FF FF FF FF FF FF FF - 8 uint8_t,
                                          FF FF FF FF FF FF FF FF - 8 uint8_t,
Cs - Контрольная сумма                    0x2C - 1 uint8_t, unsigned char (uint8_t)
//------------------------------------------------------------------------------
/*
Пример команды Cmd_Pult_Key_Read 0x25:
C0 25 19
0  1  2  = 3bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Pult_Key_Read       0x25 - 1 uint8_t, unsigned char (uint8_t)
Cs - Контрольная сумма                    0x19 - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Pult_Key_Read:
C0 25 00 28 55 01 16 C0 D5 17 00 00 68 71
0  1  2  3  4  5  6  7  8  9  10 11 12 13 = 14bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Pult_Key_Read       0x25 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата                        0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Status - 28 55 в интеловском формате = 0x5528 - 1 uint16_t
                                            (uint16_t)1 << 3  - ST_PULT_LED_KEY
                                            (uint16_t)1 << 5  - ST_PULT_CFG
                                            (uint16_t)1 << 10 - ST_PULT_USER_KEY
                                            (uint16_t)1 << 12 - ST_PULT_KEY_LOCK
                                            (uint16_t)1 << 14 - ST_PULT_PWRON
       Ключ -   01 16 C0 D5 17 00 00 68 - 8 uint8_t,
Cs - Контрольная сумма                    0x71 - 1 uint8_t, unsigned char (uint8_t) 
//------------------------------------------------------------------------------
Пример команды Cmd_Pult_Key_Read_Cycle 0x26:
C0 26 18
0  1  2  = 3bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Pult_Key_Read_Cycle 0x26 - 1 uint8_t, unsigned char (uint8_t)
Cs - Контрольная сумма                    0x18 - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Pult_Key_Read_Cycle:
C0 26 00 28 65 01 16 C0 D5 17 00 00 68 60
0  1  2  3  4  5  6  7  8  9  10 11 12 13 = 14bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Pult_Key_Read_Cycle 0x26 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата                        0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Status - 28 65 в интеловском формате = 0x6528 - 1 uint16_t
                                            (uint16_t)1 << 3  - ST_PULT_LED_KEY
                                            (uint16_t)1 << 5  - ST_PULT_CFG
                                            (uint16_t)1 << 10 - ST_PULT_USER_KEY
                                            (uint16_t)1 << 13 - ST_PULT_KEY_CYCLE
                                            (uint16_t)1 << 14 - ST_PULT_PWRON
       Ключ -   01 16 C0 D5 17 00 00 68 - 8 uint8_t,
Cs - Контрольная сумма                    0x60 - 1 uint8_t, unsigned char (uint8_t)
*/
//------------------------------------------------------------------------------
Пример команды Cmd_Pult_Key_Free 0x25:
Разрешить считывание ключей и кнопок.
В ответе на команду после Code_Res передается Pult_Status.
В Pult_Status сбрасывается в "0" бит ST_PULT_KEY_LOCK.
C0 25 19
0  1  2  = 3bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Pult_Key_Free       0x25 - 1 uint8_t, unsigned char (uint8_t)
Cs - Контрольная сумма                    0x19 - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Pult_Key_Free:
C0 25 00 01 40 D8
0  1  2  3  4  5  = 6bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Pult_Key_Free       0x25 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата                        0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Status - 01 40 в интеловском формате = 0x4001 - 1 uint16_t
                                            (uint16_t)1 << 5  - ST_PULT_CFG - пользовательские ключи не сконфигурированы.
                                            (uint16_t)1 << 14 - ST_PULT_PWRON - питание АВТОМАТА включить.
Cs - Контрольная сумма                    0xD8 - 1 uint8_t, unsigned char (uint8_t) 
//------------------------------------------------------------------------------
Пример команды Cmd_Pult_Key_Lock 0x26:
Запретить считывание ключей и кнопок. До получения команды Cmd_Pult_Key_Free.
В ответе на команду после Code_Res передается Pult_Status.
В Pult_Status устанавливается в "1" бит ST_PULT_KEY_LOCK.
В Pult_Status будут передаваться значения ключа, кнопок и С/Д, полученные до команды Cmd_Pult_Key_Lock.
C0 26 18
0  1  2  = 3bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Pult_Key_Free       0x26 - 1 uint8_t, unsigned char (uint8_t)
Cs - Контрольная сумма                    0x18 - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Pult_Key_Free:
C0 26 00 00 50 C8
0  1  2  3  4  5  = 6bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Pult_Key_Free       0x26 - 1 uint8_t, unsigned char (uint8_t)
Res - Код возврата                        0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Status - 00 50 в интеловском формате = 0x5000 - 1 uint16_t
                                            (uint16_t)1 << 12 - Признак запрета считывания ключей. 1 - ключи не считываются. Сбрасывется по команде Cmd_Pult_Key_Free.
                                            (uint16_t)1 << 14 - ST_PULT_PWRON - питание АВТОМАТА включить.


Cs - Контрольная сумма                    0xC8 - 1 uint8_t, unsigned char (uint8_t)
//------------------------------------------------------------------------------
Пример команды Cmd_Pult_Beep 0x27:
Пропищать указанное количество раз.
В ответе на команду после Code_Res передается Pult_Status.
C0 27 05 12
0  1  2  3  = 4bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Pult_Beep           0x27 - 1 uint8_t, unsigned char (uint8_t)
Data - Количество бипов                   0x05 - 1 uint8_t, unsigned char (uint8_t)
        Максимальное количество бипов - 10. Максимальная полная длительность - 2 сек.
        Длительность 1 бипа - 0,1 сек.
        Интервал между бипами - 0,1 сек.
        Пока не закончится начатая серия бипов, другая не начнется и будет отменена.
Cs - Контрольная сумма                    0x12 - 1 uint8_t, unsigned char (uint8_t) 

Пример ответа на команду Cmd_Pult_Beep:
C0 27 00 01 40 D6
0  1  2  3  4  5  = 6bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Pult_Beep           0x27 - 1 uint8_t, unsigned char (uint8_t)
Code_Res - Код возврата                   0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Status - 01 40 в интеловском формате = 0x4001 - 1 uint16_t
                                            (uint16_t)1 << 5  - ST_PULT_CFG - пользовательские ключи не сконфигурированы.
                                            (uint16_t)1 << 14 - ST_PULT_PWRON - питание АВТОМАТА включить.
Cs - Контрольная сумма                    0xD6 - 1 uint8_t, unsigned char (uint8_t)
//------------------------------------------------------------------------------
Пример команды Cmd_Pult_Led 0x28:
Управление С/Д.
С/Д, биты которых установлены в "1", включить.
С/Д, биты которых сброшены в "0", выключить.
В ответе на команду после Code_Res передается Pult_Status.
C0 28 12 04
0  1  2  = 4bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Pult_Beep           0x28 - 1 uint8_t, unsigned char (uint8_t)
Data - Комбинация светодиодов             0x12 - 1 uint8_t, unsigned char (uint8_t)
                                            (uint16_t)1 << 1 - PULT_LED_RAZRESHIT - включить LED_RAZRESHIT.
                                            (uint16_t)1 << 4 - PULT_LED_TOVAR - включить LED_TOVAR.
Cs - Контрольная сумма                    0x04 - 1 uint8_t, unsigned char (uint8_t)

Пример ответа на команду Cmd_Pult_Led:
C0 28 00 12 40 C4
0  1  2  3  4  5  = 6bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Pult_Led            0x28 - 1 uint8_t, unsigned char (uint8_t)
Code_Res - Код возврата                   0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Status - 12 40 в интеловском формате = 0x4012 - 1 uint16_t
                                            (uint16_t)1 << 1 - ST_PULT_LED_RAZRESHIT - включен LED_RAZRESHIT.
                                            (uint16_t)1 << 4 - ST_PULT_LED_TOVAR - включен LED_TOVAR.
                                            (uint16_t)1 << 14 - ST_PULT_PWRON - питание АВТОМАТА включить.
Cs - Контрольная сумма                    0xC4 - 1 uint8_t, unsigned char (uint8_t)
//------------------------------------------------------------------------------
Пример команды Cmd_Pult_Beep_Led 0x29
Одновременное упрение БИПЕРОМ и С/Д.
Байт 2 содержит число бипов. Если байт = 0, БИПЕР пищать не будет.
Байт 3 содержит комбинацию С/Д.
С/Д, биты которых установлены в "1", включить.
С/Д, биты которых сброшены в "0", выключить.
В ответе на команду после Code_Res передается Pult_Status.
C0 29 05 12 FE
0  1  2  3  4  = 5bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Pult_Beep           0x29 - 1 uint8_t, unsigned char (uint8_t)
Data - Количество бипов,                  0x05 - 5 бипов по 0,1 сек с интервалом 0,1 сек - 1 байт
        Комбинация светодиодов            0x12 - 1 uint8_t, unsigned char (uint8_t)
                                            (uint16_t)1 << 1 - PULT_LED_RAZRESHIT - включить LED_RAZRESHIT.
                                            (uint16_t)1 << 4 - PULT_LED_TOVAR - включить LED_TOVAR.
Cs - Контрольная сумма                    0xFE - 1 uint8_t, unsigned char (uint8_t)

Пример ответа на команду Cmd_Pult_Beep_Led:
C0 29 00 12 C0 43
0  1  2  3  4  5  = 6bt
ADDR - Адрес устройства                   0xC0 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Pult_Led            0x28 - 1 uint8_t, unsigned char (uint8_t)
Code_Res - Код возврата                   0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Status - 12 C0 в интеловском формате = 0xC012 - 1 uint16_t
                                            (uint16_t)1 << 1 - ST_PULT_LED_RAZRESHIT - включен LED_RAZRESHIT.
                                            (uint16_t)1 << 4 - ST_PULT_LED_TOVAR - включен LED_TOVAR.
                                            (uint16_t)1 << 14 - ST_PULT_PWRON - питание АВТОМАТА включить.
                                            (uint16_t)1 << 15 - ST_PULT_BEEP - пищит.
Cs - Контрольная сумма                    0x43 - 1 uint8_t, unsigned char (uint8_t)
//------------------------------------------------------------------------------
/*
	
						КОМАНДЫ ДИСПЕТЧЕРА.
				
*/

Пример команды Cmd_Telemetry 0x03 // Запрос телеметрии.

typedef struct{
  uint8_t  Addr;          //Адрес ЯЧЕЙКИ из которой выдается товар.
  uint8_t  Quant;         //Количество выданного товара.
  uint32_t Disp_StatusEx; //Расширенный статус ДИСПЕТЧЕРА.
  uint16_t Cell_Status;   //Статус ЯЧЕЙКИ.
}Prodaja_Telemetry_Str_t; //8Bt

80 03 7A
0  1  2  = 3 bt

ADDR - Адрес устройства         0x80 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Telemetr  0x03 - 1 uint8_t, unsigned char (uint8_t)
Cs - Контрольная сумма          0x7A - 1 uint8_t, unsigned char (uint8_t)

Пример ответа на команду Cmd_Telemetry
80 03 00 01 02 0C 00 0F 00 06 00 57
0  1  2  3  4  5  6  7  8  9  10 11 = 12 bt

ADDR - Адрес устройства         0x80 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Prodaja   0x46 - 1 uint8_t, unsigned char (uint8_t)
Code_Res - Код возврата         0x00 - 1 uint8_t, unsigned char (uint8_t)
Data - Данные телеметрии определяются структурой Prodaja_Telemetry_Str_t, 12 бт.
                                0x01 - Адрес ЯЧЕЙКИ
								0x02 - Выдано 2 единицы товара. Прошло через датчик пролета.
								0C 00 0F 00 - Расширенный статус ДИСПЕТЧЕРА.
								ST_DISP_TR_H       ((uint32_t)1 << 2)
                                ST_DISP_TR_V       ((uint32_t)1 << 3)
                                ST_DISP_PWR_LEFT   ((uint32_t)1 << 16)
                                ST_DISP_PWR_RIGHT  ((uint32_t)1 << 17)
                                ST_DISP_PWR_PANEL  ((uint32_t)1 << 18)
                                ST_DISP_PRODAJA    ((uint32_t)1 << 19)
								06 00 - Статус ЯЧЕЙКИ
                                ST_CELL_SENS_MOTOR ((uint16_t)1 << 1)
                                ST_CELL_SENS_NAL   ((uint16_t)1 << 2)
Cs - Контрольная сумма          0xA8 - 1 uint8_t, unsigned char (uint8_t)
//-------------------------------------------------------------------------------
Пример команды Cmd_Prodaja 0x46 // Продать товар.
Выдать товар из указанной ЯЧЕЙКИ в указанном количестве и с указанным типом старта горизонтального транспортера.
Команда адресуется ДИСПЕТЧЕРУ и им же выполняется.

typedef struct {
  uint8_t Addr;  // Адрес ЯЧЕЙКИ из которой надо выдать товар.
  uint8_t Quant; // Количество единиц товара.
  uint8_t Trans_Hor_Start_Type; // Тип старта гор.транса: быстрый - Cmd_Trans_Hor, медленный - Cmd_Trans_Hor_Slow.
  uint8_t Par; // доп. параметр. Сейчас не используется.
} Prodaja_Str_t;

80 46 01 05 18 00 1A
0  1  2  3  4  5  6  = 7 bt

ADDR - Адрес устройства         0x80 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Prodaja   0x46 - 1 uint8_t, unsigned char (uint8_t)
Data - Данные для выдачи определяются структурой Prodaja_Str_t, 4 байта
                                0x01 - Адрес ЯЧЕЙКИ 1.
                                0x05 - Количество единиц товара 5. Максимальное количество пачек за 1 продажу TOVAR_QUANT_MAX 10.
                                0x18 - Тип старта горизонтального транспортера: - Cmd_Trans_Hor_Slow 0x18 // Медленный старт.
                                                                                - Cmd_Trans_Hor      0x13 // Быстрый старт.
                                0x00 - Параметр. Сейчас не используется.
Cs - Контрольная сумма          0x1A - 1 uint8_t, unsigned char (uint8_t)

Пример ответа на команду Cmd_Prodaja
80 46 00 38
0  1  2  3  = 4 bt
ADDR - Адрес устройства         0x80 - 1 uint8_t, unsigned char (uint8_t)
Cmd - Код команды Cmd_Prodaja   0x46 - 1 uint8_t, unsigned char (uint8_t)
Code_Res - Код возврата         0x00 - 1 uint8_t, unsigned char (uint8_t)
Cs - Контрольная сумма          0x38 - 1 uint8_t, unsigned char (uint8_t)

Команда Cmd_Prodaja выполняется только при свободной периферии.
Т.е. транспортеры, датчик пролета не должны быть включены другими командами.
На время выполнения команды Cmd_Prodaja все команды кроме Cmd_Telemetry игнорируются.
На время выполнения команды Cmd_Prodaja ПУЛЬТ КАССИРА выключается, включается после выполнения команды.

После получения ответа на команду Cmd_Prodaja с Code_Res == RES_OK, надо пинговать диспетчер командой запроса телеметрии Cmd_Telemetry 3-5 раз в сек.
В ответе контролировать количество выданного товара и состояние ST_DISP_PRODAJA.
При выполнении команды бит ST_DISP_PRODAJA установлен в '1'.
Когда команда выполнитя/завершится бит ST_DISP_PRODAJA сбросится в '0', в телеметрии будет указано количество выданного товара (зафиксированного датчиком пролета), оно может быть меньше требуемого.
Обязательно проконтролировать Code_Res. Если выдача прошла без проблем, то Code_Res == RES_OK. Иначе надо анализировать статусы ДИСПЕТЧЕРА и ЯЧЕЙКИ и принимать решение в соответствии с алгоритмом.
//-------------------------------------------------------------------------------



#endif
#endif
