FROM node:latest AS build
WORKDIR /usr/src/app
COPY . .
RUN npm install
RUN npm run build

# İkinci aşama: Derlenmiş uygulamayı Nginx üzerine kopyala
FROM nginx:latest
COPY --from=build /usr/src/app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]