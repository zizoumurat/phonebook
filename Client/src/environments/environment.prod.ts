import { NgxLoggerLevel } from 'ngx-logger';

export const environment = {
  production: true,
  logLevel: NgxLoggerLevel.OFF,
  serverLogLevel: NgxLoggerLevel.ERROR,
  apiUrl: 'http://ocelon.api/api/',
  hubUrl: 'http://report.api/notificationhub'
};
