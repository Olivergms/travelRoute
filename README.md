# Sobre
Api de rota de viagens dockerizada em .NET 8 e testes unitários  \
Tecnologias utilizadas : 
- .NET 8
- PostgreSql
- Docker

---

### Pré-Requisitos
 #### Você tem duas maneiras de executar a api, via **Docker** ou **Local**

 #### Docker
- **Docker Engine**: Certifique-se de que o Docker Engine esteja instalado e em execução no seu sistema (por meio do WSL ou de outro ambiente).

#### Local
- .NET
- Visual Studio
- Banco PostgreSql

---

### Instação

1. **Clone o repositório**:
   ```bash
   git clone https://github.com/Olivergms/travelRoute.git
   cd [travelRoute]
   ```

2. **Para executar o projeto** certifique-se de estar rodando o wsl.
   ```bash
   docker-compose up -d
   ```

3. **Abrindo o sereviço** 
    - Abra o seu navegador
    - Acesse **https://localhost:8080/swagger**




> **Note**: Para rodar local você terá que abrir o visão studio e selecionar o perfil `local`. Se a versão do banco não estiver rodando na sua maquina, altere a string de conexão na linha 10 do arquivo `appsettings.json` no projeto `travelRoute-api`. 

