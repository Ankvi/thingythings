FROM node:18-alpine AS build

WORKDIR /app
COPY . .
RUN yarn
RUN yarn build

FROM node:18-alpine AS deploy

WORKDIR /app
COPY --from=build /app/package.json .
COPY --from=build /app/build .
RUN yarn --prod

CMD [ "node", "index.js" ]
