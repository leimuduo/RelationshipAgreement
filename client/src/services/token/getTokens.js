import { commonService } from "../common";
import { tokenEndpoint } from "./endpoints";

export const getTokens = (userId) => commonService.get(`${tokenEndpoint}/${userId}`)