FROM node:alpine AS app
WORKDIR /app
COPY . .
RUN npm ci && npm run build

FROM nginx:alpine
COPY /dist/mondongo-ui /usr/share/nginx/html
EXPOSE 80