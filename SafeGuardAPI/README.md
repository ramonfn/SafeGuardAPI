
# SAFE.Guard - Sistema Inteligente de Monitoramento e Preven��o de Desastres Naturais

**SAFE.Guard** � um sistema inteligente de monitoramento que utiliza sensores ambientais para calcular riscos de desastres naturais, como inunda��es, inc�ndios e deslizamentos de terra, e emite alertas preventivos para proteger popula��es vulner�veis.

### **Integrantes do Projeto**
- **Nome**: Marcus Vinicius de Souza Calazans - **RM**: 556620
- **Nome**: Felipe Nogueira Ramon - **RM**: 555335
- **Nome**: Fernando Hitoshi Hiroshima - **RM**: 556730

### **Introdu��o**
O projeto **SAFE.Guard** integra uma esta��o IoT com sensores de chuva, press�o atmosf�rica, umidade e inclina��o do solo. Esses sensores coletam dados ambientais em tempo real, e uma **API RESTful** desenvolvida em .NET Core processa e emite alertas preventivos por meio de um aplicativo m�vel e painel web.

O sistema busca monitorar condi��es de risco e fornecer informa��es relevantes e em tempo real para a popula��o, garantindo maior seguran�a em regi�es propensas a desastres naturais.

### **Arquitetura do Sistema**
A arquitetura do sistema � composta por cinco componentes principais interconectados:

1. **API RESTful** (Backend):
   - Desenvolvida em .NET Core, a API � respons�vel pelo processamento dos dados recebidos dos sensores, c�lculo de riscos e envio de alertas.

2. **Banco de Dados Oracle**:
   - Armazena todas as informa��es sobre sensores, esta��es de monitoramento, leituras de dados e alertas gerados.

3. **Sensores IoT**:
   - Sensores de chuva, umidade, press�o atmosf�rica e inclina��o do solo s�o os principais componentes de hardware que coletam os dados ambientais.

### **Tecnologias Utilizadas**
- **Backend**: .NET 8 / .NET Core (C#)
- **Banco de Dados**: Oracle
- **APIs**: RESTful

### **Testes**

#### Testando com o Swagger

Aqui est�o dois exemplos para cada classe, com as requisi��es **POST**, **GET**, **PUT** e **DELETE** para testar a API no **Swagger**.

#### **1. Esta��o**

##### Criar Esta��o (POST)

No **Swagger**, envie uma requisi��o **POST** para `http://localhost:5000/api/estacao` com o corpo em **JSON**:

```json
{
  "nome": "Esta��o 1",
  "status": "Ativa"
}
```

##### Obter Esta��es (GET)

Para obter todas as esta��es, envie uma requisi��o **GET** para `http://localhost:5000/api/estacao`.

##### Atualizar Esta��o (PUT)

Para atualizar uma esta��o existente, envie uma requisi��o **PUT** para `http://localhost:5000/api/estacao/{id}`, substituindo `{id}` pelo ID da esta��o e o corpo em **JSON**:

```json
{
  "idEstacao":,
  "nome": "Esta��o 1 Atualizada",
  "status": "Inativa"
}
```

##### Excluir Esta��o (DELETE)

Para excluir uma esta��o, envie uma requisi��o **DELETE** para `http://localhost:5000/api/estacao/{id}`, substituindo `{id}` pelo ID da esta��o.

#### **2. Sensor**

##### Criar Sensor (POST)

Para criar um sensor, envie uma requisi��o **POST** para `http://localhost:5000/api/sensor` com o corpo em **JSON**:

```json
{
  "tipoSensor": "Umidade",
  "estacaoId": 1
}
```

##### Obter Sensores (GET)

Para obter todos os sensores, envie uma requisi��o **GET** para `http://localhost:5000/api/sensor`.

##### Atualizar Sensor (PUT)

Para atualizar um sensor existente, envie uma requisi��o **PUT** para `http://localhost:5000/api/sensor/{id}`, substituindo `{id}` pelo ID do sensor e o corpo em **JSON**:

```json
{
  "idSensor": ,
  "tipoSensor": "Umidade",
  "estacaoId": 2
}
```

##### Excluir Sensor (DELETE)

Para excluir um sensor, envie uma requisi��o **DELETE** para `http://localhost:5000/api/sensor/{id}`, substituindo `{id}` pelo ID do sensor.

#### **3. Leitura**

##### Criar Leitura (POST)

Para criar uma leitura de sensor, envie uma requisi��o **POST** para `http://localhost:5000/api/leitura` com o corpo em **JSON**:

```json
{
  "sensorId": 1,
  "valor": 15.5,
  "dataHora": "2025-06-07T10:00:00"
}
```

##### Obter Leituras (GET)

Para obter todas as leituras, envie uma requisi��o **GET** para `http://localhost:5000/api/leitura`.

##### Atualizar Leitura (PUT)

Para atualizar uma leitura existente, envie uma requisi��o **PUT** para `http://localhost:5000/api/leitura/{id}`, substituindo `{id}` pelo ID da leitura e o corpo em **JSON**:

```json
{
  "idLeitura": ,
  "sensorId": 1,
  "valor": 16.0,
  "dataHora": "2025-06-07T12:00:00"
}
```

##### Excluir Leitura (DELETE)

Para excluir uma leitura, envie uma requisi��o **DELETE** para `http://localhost:5000/api/leitura/{id}`, substituindo `{id}` pelo ID da leitura.

#### **4. Alerta**

##### Criar Alerta (POST)

Para criar um alerta, envie uma requisi��o **POST** para `http://localhost:5000/api/alerta` com o corpo em **JSON**:

```json
{
  "mensagem": "Alto risco de deslisamento",
  "dataAlerta": "2025-06-08T19:35:41.609Z",
  "riscoId": 1
}
```

##### Obter Alertas (GET)

Para obter todos os alertas, envie uma requisi��o **GET** para `http://localhost:5000/api/alerta`.

##### Atualizar Alerta (PUT)

Para atualizar um alerta existente, envie uma requisi��o **PUT** para `http://localhost:5000/api/alerta/{id}`, substituindo `{id}` pelo ID do alerta e o corpo em **JSON**:

```json
{
  "idAlerta": ,
  "mensagem": "Alto risco de deslisamento",
  "dataAlerta": "2025-06-08T19:35:41.609Z",
  "riscoId": 2
}
```

##### Excluir Alerta (DELETE)

Para excluir um alerta, envie uma requisi��o **DELETE** para `http://localhost:5000/api/alerta/{id}`, substituindo `{id}` pelo ID do alerta.

#### **5. Risco**

##### Criar Risco (POST)

Para criar um risco, envie uma requisi��o **POST** para `http://localhost:5000/api/risco` com o corpo em **JSON**:

```json
{
  "idEstacao": 1,
  "nivel": 3,
  "descricao": "Risco de inunda��o devido � alta precipita��o"
}
```

##### Obter Riscos (GET)

Para obter todos os riscos, envie uma requisi��o **GET** para `http://localhost:5000/api/risco`.

##### Atualizar Risco (PUT)

Para atualizar um risco existente, envie uma requisi��o **PUT** para `http://localhost:5000/api/risco/{id}`, substituindo `{id}` pelo ID do risco e o corpo em **JSON**:

```json
{
  "idRisco": 21,
  "idEstacao": 1,
  "nivel": 3,
  "descricao": "Risco de inc�ndio devido � seca prolongada"
}
```

##### Excluir Risco (DELETE)

Para excluir um risco, envie uma requisi��o **DELETE** para `http://localhost:5000/api/risco/{id}`, substituindo `{id}` pelo ID do risco.

---


