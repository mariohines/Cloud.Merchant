import {GeneralComponent} from "./general/general.component";
import {OptionsComponent} from "./options/options.component";
import {PaymentGatewaysComponent} from "./payment-gateways/payment-gateways.component";

export const components: any[] = [
  GeneralComponent,
  OptionsComponent,
  PaymentGatewaysComponent
];

export * from './general/general.component';
export * from './options/options.component';
export * from './payment-gateways/payment-gateways.component';
