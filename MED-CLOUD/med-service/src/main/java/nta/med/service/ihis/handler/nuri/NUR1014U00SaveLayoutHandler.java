package nta.med.service.ihis.handler.nuri;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.nur.Nur1014;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1014Repository;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1014U00SaveLayoutHandler extends ScreenHandler<NuriServiceProto.NUR1014U00SaveLayoutRequest, NuriServiceProto.NUR1014U00SaveLayoutResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(NUR1014U00SaveLayoutHandler.class);  
	
	@Resource
	private Nur1014Repository nur1014Repository;
	
	@Resource
	private Ocs2005Repository ocs2005Repository;

	@Override
	@Transactional
	public NuriServiceProto.NUR1014U00SaveLayoutResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1014U00SaveLayoutRequest request) throws Exception {
				
		NuriServiceProto.NUR1014U00SaveLayoutResponse.Builder response = NuriServiceProto.NUR1014U00SaveLayoutResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		
		List<NuriModelProto.NUR1014U00grdNur1014Info> grdNur1014 = request.getItemsList();
		for(NuriModelProto.NUR1014U00grdNur1014Info item : grdNur1014){
			if(DataRowState.ADDED.getValue().equals(item.getDataRowState())){
//				try{
					ComboListItemInfo result = nur1014Repository.callPrInpJaewonRangeCheck(hospCode, CommonUtils.parseDouble(item.getFkinp1001()), item.getOutDate(),
							item.getOutTime(), item.getInHopeDate(), item.getInHopeTime());
					if(!"0".equals(result.getCode())){
						LOGGER.info(result.getCodeName());
						response.setResult("false").setMessage(result.getCodeName());
						throw new ExecutionException(response.build());
					}
//				}catch(Exception e){
//					LOGGER.info("PR_INP_JAEWON_RANGE_CHECK_Error");
//					response.setResult("false").setMessage("PR_INP_JAEWON_RANGE_CHECK_Error");
//					throw new ExecutionException(response.build());
//				}
				
				if(request.getNutEndYn().equals("false")){
					try{
						ocs2005Repository.callPrOcsCreateStopSiksa(item.getNutStartDate(), item.getNutStartKini(), item.getNutEndDate(), item.getNutEndKini(),
								item.getBunho(), hospCode, item.getFkinp1001(), userId, item.getFlag(), "I", "");						
					}catch(Exception e){
						LOGGER.info("PR_OCS_CREATE_STOP_SIKSA_Error");
						response.setResult("false").setMessage("PR_OCS_CREATE_STOP_SIKSA_Error");
						throw new ExecutionException(response.build());
					}
				}
				response.setPrintFlag("true");
				insertNur1014(item, hospCode, userId);
			}else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())){
				if(nur1014Repository.updateNur1014U00grdNur1014(hospCode, userId, item.getInHopeDate(),
						item.getInHopeTime().replace(":", ""),
						item.getInTrueDate(),
						item.getInTrueTime().replace(":", ""),
						item.getNutStartDate(),
						item.getNutStartKini(),
						item.getNutEndDate(),
						item.getNutEndKini(),
						item.getOutObject(),
						item.getFlag(),
						item.getNutEndYn(),
						item.getDestIshome(),
						item.getDestAddr(),
						item.getDestTel(),
						item.getBunho(),
						CommonUtils.parseDouble(item.getFkinp1001()),
						item.getOutDate(),
						item.getOutTime().replace(":", "")) < 0){
					throw new ExecutionException(response.setResult("false").build());
				}
			}else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())){
				if(nur1014Repository.deleteNur1014U00grdNur1014(hospCode, item.getBunho(), CommonUtils.parseDouble(item.getFkinp1001()),
						item.getOutDate(), item.getOutTime().replace(":", "")) < 0){
					throw new ExecutionException(response.setResult("false").build());
				}
			}
		}
		response.setResult("true");
		return response.build();
	}
	
	private void insertNur1014(NuriModelProto.NUR1014U00grdNur1014Info item, String hospCode, String userId){
		Nur1014 nur1014 = new Nur1014();
		nur1014.setSysDate(new Date());
		nur1014.setSysId(userId);
		nur1014.setUpdDate(new Date());
		nur1014.setUpdId(userId);
		nur1014.setHospCode(hospCode);
		nur1014.setBunho(item.getBunho());
		nur1014.setFkinp1001(CommonUtils.parseDouble(item.getFkinp1001()));
		nur1014.setOutDate(DateUtil.toDate(item.getOutDate(), DateUtil.PATTERN_YYMMDD));
		nur1014.setOutTime(item.getOutTime().replace(":", ""));
		nur1014.setInHopeDate(DateUtil.toDate(item.getInHopeDate(), DateUtil.PATTERN_YYMMDD));
		nur1014.setInHopeTime(item.getInHopeTime().replace(":", ""));
		nur1014.setInTrueDate(DateUtil.toDate(item.getInTrueDate(), DateUtil.PATTERN_YYMMDD));
		nur1014.setInTrueTime(item.getInTrueTime().replace(":", ""));
		nur1014.setNutStartDate(DateUtil.toDate(item.getInTrueDate(), DateUtil.PATTERN_YYMMDD));
		nur1014.setNutStartKini(item.getNutStartKini());
		nur1014.setNutEndDate(DateUtil.toDate(item.getNutEndDate(), DateUtil.PATTERN_YYMMDD));
		nur1014.setNutEndKini(item.getNutEndKini());
		nur1014.setOutObject(item.getOutObject());
		nur1014.setWoichulWoibakGubun(item.getFlag());
		nur1014.setNutEndYn(item.getNutEndYn());
		nur1014.setDestIshome(item.getDestIshome());
		nur1014.setDestAddr(item.getDestAddr());
		nur1014.setDestTel(item.getDestTel());
		
		nur1014Repository.save(nur1014);
	}
}
