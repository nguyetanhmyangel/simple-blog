# config nswag:

## 1. create 1 file json: nswag-lock.json have : "runtime": "Net80", "typeScriptVersion": 5.3

### 2. add: "nswag-admin": "node node_modules/nswag/bin/nswag.js run nswag-admin.json" in script of package.json

#### 3. add folder environments

#### 4. add { provide: ADMIN_API_BASE_URL, useValue: environment.API_URL } vao provider of app.
 
