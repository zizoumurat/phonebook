# Builder aşaması
FROM node:14 AS builder

# Builder'ın çalışma dizinini belirle
WORKDIR /app

# Angular uygulamasının bağımlılıklarını yükle
COPY package*.json ./
RUN npm install

# Angular uygulamasını kopyala
COPY . .

# Angular uygulamasını derle
RUN npm run build

# Nginx aşaması
FROM nginx:alpine

# Nginx konfigürasyonunu değiştir
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Builder aşamasından derlenmiş uygulamayı al
COPY --from=builder /app/dist /usr/share/nginx/html

# Gerekirse, uygulamanın çalıştığı portu belirt
EXPOSE 80

# Nginx'ı başlat
CMD ["nginx", "-g", "daemon off;"]
