package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.service.ihis.proto.OcsiModelProto.OCS2003U99grdInp1001Info;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U99SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS2003U99SaveLayoutHandler extends ScreenHandler<OcsiServiceProto.OCS2003U99SaveLayoutRequest, SystemServiceProto.UpdateResponse>{
	private static final Log LOGGER = LogFactory.getLog(OCS2003U99SaveLayoutHandler.class);
	
	@Resource
	private Ocs2003Repository ocs2003Repository;
	@Resource
	private Inp1001Repository inp1001Repository;
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U99SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		if (CollectionUtils.isEmpty(request.getGrdInpList())) {
			LOGGER.info("List SaveLayout : null!");
			response.setResult(false);
			return response.build();
		}
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String userId; 
		if (request.getUserGubun().equals(request.getDoctor())) {
			userId = request.getUserDoctor();
		} else { 
			userId = request.getUserId();
		}
		List<OCS2003U99grdInp1001Info> list = request.getGrdInpList();
		for (OCS2003U99grdInp1001Info item : list) {
			if (DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
				// Do nothing
			} else if (DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
				if ("Y".equals(item.getToiwonGojiYn())) {
					
					ocs2003Repository.callPrDrgAutoOcsBannab(hospCode, language, item.getToiwonResDate(), userId, item.getFkinp1001());
					
					String yCheck = drg3010Repository.callFnDrgToiwonOrderChk(hospCode, "", item.getBunho(), item.getFkinp1001());
					if (yCheck != null && "Y".equals(yCheck)) {
						LOGGER.info("yCheck = Y || null!");
						response.setResult(false);
						response.setMsg("003");
						return response.build();
					}
				}
				
				String simsaMagamGubun = inp1001Repository.getINP1001simsaMagam(hospCode, item.getFkinp1001());
				if (!StringUtils.isEmpty(simsaMagamGubun)) {
					if ("2".equals(simsaMagamGubun)) {
						LOGGER.info("simsaMagamGubun = 2 : fail!");
						response.setResult(false);
						response.setMsg("001");
						return response.build();
					} else if ("4".equals(simsaMagamGubun)) {
						LOGGER.info("simsaMagamGubun = 4 : fail!");
						response.setResult(false);
						response.setMsg("002");
						return response.build();
					}
				}
				
				String ioFlag = ocs2003Repository.callPrOcsTransInputGubunD6(hospCode, item.getBunho(), item.getFkinp1001(), item.getToiwonGojiYn(), userId);
				String msg = "";
				if (ioFlag != null && !"0".equals(ioFlag)) {
					
					// set msg prefer the "PR_OCS_TRANS_INPUT_GUBUN_D6" procedure
					switch (ioFlag) {
					case "D":
						msg = "SQLWAYS_EVAL# EX";
						break;
					case "V":
						msg = "VALUE_ERROR";
						break;
					case "T":
						msg = "TOO_MANY_ROWS";
						break;
					}
					
					LOGGER.info("ioFlag = 0 : fail!");
					response.setResult(false);
					response.setMsg("PR_OCS_TRANS_INPUT_GUBUN_D6 Error " + ioFlag + "\n\n" + msg);
					return response.build();
				}
				
				if (!StringUtils.isEmpty(item.getToiwonResDate()) && "Y".endsWith(item.getToiwonResDate())) {
					String ioErr = ocs2003Repository.callPrOcsDeleteInpOrderToiwon(hospCode, userId, item.getBunho(), item.getFkinp1001(), item.getToiwonResDate(), item.getSigiMagamDate(), item.getKiGubun());
					if (!"0".equals(ioErr)) {
						LOGGER.info("ioErr = 0 : fail!");
						response.setResult(false);
						return response.build();
					}
				}
				
				if (!"Y".equals(request.getDoubleYn())) {
					if (!StringUtils.isEmpty(item.getToiwonResDate())) {
						exeInp1001Update(item, "Y", userId, hospCode);
					} else {
						exeInp1001Update(item, "N", userId, hospCode);
					}
				} else {
					if (!StringUtils.isEmpty(item.getToiwonResTime())) {
						exeInp1001Update(item, "1", userId, hospCode);
					} else {
						exeInp1001Update(item, "2", userId, hospCode);
					}
				}
			} else if (DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
				//Do nothing
			} else {
				LOGGER.info("Data row state : null!");
				response.setResult(false);
				return response.build();
			}
		}
		response.setResult(true);
		return response.build();
	}
	
	private void exeInp1001Update(OCS2003U99grdInp1001Info info, String flg, String userId, String hospCode) {
		switch (flg) {
		case "Y":
			if (inp1001Repository.updateINP1001U01OCS2003U99SaveLayout(	hospCode, userId, 
																		DateUtil.toDate(info.getToiwonResDate(), DateUtil.PATTERN_YYMMDD), 
																		info.getToiwonResTime(), 
																		info.getToiwonGojiYn(), 
																		DateUtil.toDate(info.getSigiMagamDate(), DateUtil.PATTERN_YYMMDD), 
																		info.getSigiMagamDate() == null ? "N" : "Y",
																		info.getKiGubun(), 
																		info.getResult(), 
																		info.getBunho())> 0) {
				LOGGER.info("Update INP1001 case Y: success!");
			} else {
				LOGGER.info("Update INP1001 case Y: fail!");
			}
			break;
		case "N":
			if (inp1001Repository.updateINP1001U01OCS2003U99SaveLayout(hospCode, userId, null, null, "N", null, null, null, null, info.getBunho())> 0) {
				LOGGER.info("Update INP1001 case N: success!");
			} else {
				LOGGER.info("Update INP1001 case N: fail!");
			}
			break;
		case "1":
			if (inp1001Repository.updateINP1001U01OCS2003U99SaveLayoutExt(	hospCode, userId, 
																			DateUtil.toDate(info.getToiwonResDate(), DateUtil.PATTERN_YYMMDD), 
																			info.getToiwonResTime(), 
																			info.getToiwonGojiYn(), 
																			DateUtil.toDate(info.getSigiMagamDate(), DateUtil.PATTERN_YYMMDD),
																			info.getSigiMagamDate() == null ? "N" : "Y",
																			info.getKiGubun(), 
																			info.getResult(), 
																			CommonUtils.parseDouble(info.getFkinp1001()))> 0) {
				LOGGER.info("Update INP1001 case 1: success!");
			} else {
				LOGGER.info("Update INP1001 case 1: fail!");
			}
			break;
		case "2":
			if (inp1001Repository.updateINP1001U01OCS2003U99SaveLayoutExt(hospCode, userId, null, null, "N", null, null, null, null, CommonUtils.parseDouble(info.getFkinp1001()))> 0) {
				LOGGER.info("Update INP1001 case 2: success!");
			} else {
				LOGGER.info("Update INP1001 case 2: fail!");
			}
			break;

		default:
			break;
		}
	}

}
