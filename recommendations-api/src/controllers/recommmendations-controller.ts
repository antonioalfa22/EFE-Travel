import { Request, Response } from 'express';
import * as soap from 'soap';

export class RecommendationsController {

    public async testSOAP(req: Request, res: Response) {
        var url = 'http://localhost:8060/SoapCollector.asmx?WSDL';
        var args = {origen: "Oviedo"};
        soap.createClientAsync(url).then((client) => {
            return client.GetVueloAsync(args);
          }).then((result) => {
            res.status(200).json(result[0]);
        });
    }

    public async getVuelos(req: Request, res: Response) {
        var url = 'http://localhost:8060/SoapCollector.asmx?WSDL';
        soap.createClientAsync(url).then((client) => {
            return client.GetVuelosAsync();
          }).then((result) => {
            res.status(200).json(result[0]);
        });
    }

}