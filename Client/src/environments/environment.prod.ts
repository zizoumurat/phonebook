import { NgxLoggerLevel } from 'ngx-logger';

export const environment = {
  production: true,
  logLevel: NgxLoggerLevel.OFF,
  serverLogLevel: NgxLoggerLevel.ERROR,
  apiUrl: 'http://localhost:6001/api/',
  hubUrl: 'http://localhost:4003/notificationhub'
};
