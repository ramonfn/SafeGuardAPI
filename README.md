
# SAFE.Guard - Sistema Inteligente de Monitoramento e Prevenção de Desastres Naturais

**SAFE.Guard** é um sistema inteligente de monitoramento que utiliza sensores ambientais para calcular riscos de desastres naturais, como inundações, incêndios e deslizamentos de terra, e emite alertas preventivos para proteger populações vulneráveis.

### **Integrantes do Projeto**
- **Nome**: Marcus Vinicius de Souza Calazans - **RM**: 556620
- **Nome**: Felipe Nogueira Ramon - **RM**: 555335
- **Nome**: Fernando Hitoshi Hiroshima - **RM**: 556730

### **Introdução**
O projeto **SAFE.Guard** integra uma estação IoT com sensores de chuva, pressão atmosférica, umidade e inclinação do solo. Esses sensores coletam dados ambientais em tempo real, e uma **API RESTful** desenvolvida em .NET Core processa e emite alertas preventivos por meio de um aplicativo móvel e painel web.

O sistema busca monitorar condições de risco e fornecer informações relevantes e em tempo real para a população, garantindo maior segurança em regiões propensas a desastres naturais.

### **Arquitetura do Sistema**
A arquitetura do sistema é composta por cinco componentes principais interconectados:

1. **API RESTful** (Backend):
   - Desenvolvida em .NET Core, a API é responsável pelo processamento dos dados recebidos dos sensores, cálculo de riscos e envio de alertas.

2. **Banco de Dados Oracle**:
   - Armazena todas as informações sobre sensores, estações de monitoramento, leituras de dados e alertas gerados.

3. **Sensores IoT**:
   - Sensores de chuva, umidade, pressão atmosférica e inclinação do solo são os principais componentes de hardware que coletam os dados ambientais.

### **Tecnologias Utilizadas**
- **Backend**: .NET 8 / .NET Core (C#)
- **Banco de Dados**: Oracle
- **APIs**: RESTful

### **Testes**

#### Testando com o Swagger

Aqui estão dois exemplos para cada classe, com as requisições **POST**, **GET**, **PUT** e **DELETE** para testar a API no **Swagger**.

#### **1. Estação**

##### Criar Estação (POST)

No **Swagger**, envie uma requisição **POST** para `http://localhost:5000/api/estacao` com o corpo em **JSON**:

```json
{
  "nome": "Estação 1",
  "status": "Ativa"
}
```

##### Obter Estações (GET)

Para obter todas as estações, envie uma requisição **GET** para `http://localhost:5000/api/estacao`.

##### Atualizar Estação (PUT)

Para atualizar uma estação existente, envie uma requisição **PUT** para `http://localhost:5000/api/estacao/{id}`, substituindo `{id}` pelo ID da estação e o corpo em **JSON**:

```json
{
  "idEstacao":,
  "nome": "Estação 1 Atualizada",
  "status": "Inativa"
}
```

##### Excluir Estação (DELETE)

Para excluir uma estação, envie uma requisição **DELETE** para `http://localhost:5000/api/estacao/{id}`, substituindo `{id}` pelo ID da estação.

#### **2. Sensor**

##### Criar Sensor (POST)

Para criar um sensor, envie uma requisição **POST** para `http://localhost:5000/api/sensor` com o corpo em **JSON**:

```json
{
  "tipoSensor": "Umidade",
  "estacaoId": 1
}
```

##### Obter Sensores (GET)

Para obter todos os sensores, envie uma requisição **GET** para `http://localhost:5000/api/sensor`.

##### Atualizar Sensor (PUT)

Para atualizar um sensor existente, envie uma requisição **PUT** para `http://localhost:5000/api/sensor/{id}`, substituindo `{id}` pelo ID do sensor e o corpo em **JSON**:

```json
{
  "idSensor": ,
  "tipoSensor": "Umidade",
  "estacaoId": 2
}
```

##### Excluir Sensor (DELETE)

Para excluir um sensor, envie uma requisição **DELETE** para `http://localhost:5000/api/sensor/{id}`, substituindo `{id}` pelo ID do sensor.

#### **3. Leitura**

##### Criar Leitura (POST)

Para criar uma leitura de sensor, envie uma requisição **POST** para `http://localhost:5000/api/leitura` com o corpo em **JSON**:

```json
{
  "sensorId": 1,
  "valor": 15.5,
  "dataHora": "2025-06-07T10:00:00"
}
```

##### Obter Leituras (GET)

Para obter todas as leituras, envie uma requisição **GET** para `http://localhost:5000/api/leitura`.

##### Atualizar Leitura (PUT)

Para atualizar uma leitura existente, envie uma requisição **PUT** para `http://localhost:5000/api/leitura/{id}`, substituindo `{id}` pelo ID da leitura e o corpo em **JSON**:

```json
{
  "idLeitura": ,
  "sensorId": 1,
  "valor": 16.0,
  "dataHora": "2025-06-07T12:00:00"
}
```

##### Excluir Leitura (DELETE)

Para excluir uma leitura, envie uma requisição **DELETE** para `http://localhost:5000/api/leitura/{id}`, substituindo `{id}` pelo ID da leitura.

#### **4. Alerta**

##### Criar Alerta (POST)

Para criar um alerta, envie uma requisição **POST** para `http://localhost:5000/api/alerta` com o corpo em **JSON**:

```json
{
  "mensagem": "Alto risco de deslisamento",
  "dataAlerta": "2025-06-08T19:35:41.609Z",
  "riscoId": 1
}
```

##### Obter Alertas (GET)

Para obter todos os alertas, envie uma requisição **GET** para `http://localhost:5000/api/alerta`.

##### Atualizar Alerta (PUT)

Para atualizar um alerta existente, envie uma requisição **PUT** para `http://localhost:5000/api/alerta/{id}`, substituindo `{id}` pelo ID do alerta e o corpo em **JSON**:

```json
{
  "idAlerta": ,
  "mensagem": "Alto risco de deslisamento",
  "dataAlerta": "2025-06-08T19:35:41.609Z",
  "riscoId": 2
}
```

##### Excluir Alerta (DELETE)

Para excluir um alerta, envie uma requisição **DELETE** para `http://localhost:5000/api/alerta/{id}`, substituindo `{id}` pelo ID do alerta.

#### **5. Risco**

##### Criar Risco (POST)

Para criar um risco, envie uma requisição **POST** para `http://localhost:5000/api/risco` com o corpo em **JSON**:

```json
{
  "idEstacao": 1,
  "nivel": 3,
  "descricao": "Risco de inundação devido à alta precipitação"
}
```

##### Obter Riscos (GET)

Para obter todos os riscos, envie uma requisição **GET** para `http://localhost:5000/api/risco`.

##### Atualizar Risco (PUT)

Para atualizar um risco existente, envie uma requisição **PUT** para `http://localhost:5000/api/risco/{id}`, substituindo `{id}` pelo ID do risco e o corpo em **JSON**:

```json
{
  "idRisco": ,
  "idEstacao": 1,
  "nivel": 3,
  "descricao": "Risco de incêndio devido à seca prolongada"
}
```

##### Excluir Risco (DELETE)

Para excluir um risco, envie uma requisição **DELETE** para `http://localhost:5000/api/risco/{id}`, substituindo `{id}` pelo ID do risco.

---

![Imagem do WhatsApp de 2025-06-08 à(s) 13 03 03_017db34f](https://github.com/user-attachments/assets/0b19ba5d-f44a-474e-bb5e-67ada6a490da)

---

### Observações técnicas:

- Os sensores se comunicam diretamente com a API por meio de requisições POST.
- A camada de **Controllers** trata as requisições e delega a lógica de negócio aos **Services**.
- O banco **Oracle** é acessado via ADO.NET.
- O sistema é modular, com entidades como `Estacao`, `Sensor`, `Leitura`, `Risco` e `Alerta`.
- O front-end consome os dados da API em tempo real para exibição visual.

