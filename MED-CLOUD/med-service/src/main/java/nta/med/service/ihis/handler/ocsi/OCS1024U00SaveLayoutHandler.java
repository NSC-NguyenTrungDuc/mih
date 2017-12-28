package nta.med.service.ihis.handler.ocsi;

import java.util.Date;
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

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.drg.Drg0120;
import nta.med.core.domain.ocs.Ocs1024;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.dao.medi.ocs.Ocs1024Repository;
import nta.med.service.ihis.proto.OcsiModelProto.OCS1024U00grdOCS1024Info;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
@Transactional
public class OCS1024U00SaveLayoutHandler extends ScreenHandler<OcsiServiceProto.OCS1024U00SaveLayoutRequest , SystemServiceProto.UpdateResponse>{
	private static final Log LOGGER = LogFactory.getLog(OCS1024U00SaveLayoutHandler.class);     
	@Resource
	private Ocs1024Repository ocs1024Repository; 
	@Resource
	private CommonRepository commonRepository; 	
	@Resource
	private Drg0120Repository drg0120Repository; 
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS1024U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Double seq = null;
        Double pkocs1024 = null;
        String hospCode = getHospitalCode(vertx, sessionId);
        String userId = request.getUserId();
        Integer result = -1;
        List<OCS1024U00grdOCS1024Info> grdList = request.getGrdSaveList();
        if(!CollectionUtils.isEmpty(grdList)){
        	for(OCS1024U00grdOCS1024Info item : grdList){
        		seq = ocs1024Repository.getMaxSeqByBunhoAnhGwa(hospCode, item.getBunho(), item.getGwa());
        		if("1".equals(request.getCallerId())){
        			if (DataRowState.ADDED.getValue().equalsIgnoreCase(item.getDataRowState())) {
        				if (item.getOrderGubun().contains("C"))
                        {
        					String validation = validationCheck(grdList, hospCode, getLanguage(vertx, sessionId));
                            if ("TEXT_2".equals(validation)){
                            	response.setResult(false);
                            	response.setMsg(validation);
                                	LOGGER.error("RESOURCE.TEXT_2");
                                throw new ExecutionException(response.build());
                            }
                            if ("F".equals(validation)){
                            	response.setResult(false);
                                throw new ExecutionException(response.build());
                            }                                
                        }
        				pkocs1024 = CommonUtils.parseDouble(commonRepository.getNextVal("OCS1024_SEQ"));
        				insertOcs1024(hospCode, userId, seq, item, pkocs1024);
        				result = 1;
                    } else if (DataRowState.MODIFIED.getValue().equalsIgnoreCase(item.getDataRowState())) {
                    	String validation = validationCheck(grdList, hospCode, getLanguage(vertx, sessionId));
                        if ("TEXT_2".equals(validation)){
                        	response.setResult(false);
                        	response.setMsg(validation);
                            	LOGGER.error("RESOURCE.TEXT_2");
                            throw new ExecutionException(response.build());
                        }
                        if ("F".equals(validation)){
                        	response.setResult(false);
                            throw new ExecutionException(response.build());
                        }
                    	Double suryang = CommonUtils.parseDouble(item.getSuryang());
                    	Double dv = CommonUtils.parseDouble(item.getDv());
                    	Double nalsu = CommonUtils.parseDouble(item.getNalsu());
                    	Double totalSuryang = CommonUtils.parseDouble(item.getTotalSuryang());
                    	Double currentSuryang = CommonUtils.parseDouble(item.getCurrentSuryang());
                    	pkocs1024 = CommonUtils.parseDouble(item.getPkocs1024());
                    	result = ocs1024Repository.updateOcs1024ByPkocs1024(hospCode, pkocs1024, userId, seq, suryang, item.getOrdDanui(), item.getDvTime(), 
                    			dv, nalsu, item.getDrgComment(), item.getBogyongCode(), totalSuryang, 
                    			currentSuryang, item.getInputUserId(), item.getJusa(), item.getJusaSpdGubun());
                    } else if (DataRowState.DELETED.getValue().equalsIgnoreCase(item.getDataRowState())) {
                    	pkocs1024 = CommonUtils.parseDouble(item.getPkocs1024());
                    	result = ocs1024Repository.deleteOcs1024ByPkocs1024(hospCode, pkocs1024);
                    }
        			
        		}else if("2".equals(request.getCallerId())){
        			if (DataRowState.ADDED.getValue().equalsIgnoreCase(item.getDataRowState())) {
        				pkocs1024 = CommonUtils.parseDouble(commonRepository.getNextVal("OCS1024_SEQ"));
        				insertOcs1024(hospCode, userId, seq, item, pkocs1024);
        				result = 1;
                    } else if (DataRowState.MODIFIED.getValue().equalsIgnoreCase(item.getDataRowState())) {
                    	Double suryang = CommonUtils.parseDouble(item.getSuryang());
                    	Double dv = CommonUtils.parseDouble(item.getDv());
                    	Double nalsu = CommonUtils.parseDouble(item.getNalsu());
                    	Double totalSuryang = CommonUtils.parseDouble(item.getTotalSuryang());
                    	Double currentSuryang = CommonUtils.parseDouble(item.getCurrentSuryang());
                    	pkocs1024 = CommonUtils.parseDouble(item.getPkocs1024());
                    	result = ocs1024Repository.updateOcs1024ByPkocs1024(hospCode, pkocs1024, userId, seq, suryang, item.getOrdDanui(), item.getDvTime(), 
                    			dv, nalsu, item.getDrgComment(), item.getBogyongCode(), totalSuryang, 
                    			currentSuryang, item.getInputUserId(), item.getJusa(), item.getJusaSpdGubun());
                    } else if (DataRowState.DELETED.getValue().equalsIgnoreCase(item.getDataRowState())) {
                    	pkocs1024 = CommonUtils.parseDouble(item.getPkocs1024());
                    	result = ocs1024Repository.deleteOcs1024ByPkocs1024(hospCode, pkocs1024);
                    }
        		}
        		if (result < 0) {
                    response.setResult(false);
                    LOGGER.error("OCS1024U00SaveLayoutHandler false ");
                    throw new ExecutionException(response.build());
                }
        	}
        }
        
        response.setResult(true);
		return response.build();
	}
	
	private void insertOcs1024(String hospCode, String sysId, Double seq, OCS1024U00grdOCS1024Info info, Double pkocs1024){
		Ocs1024 ocs1024 = new Ocs1024();
		Double suryang = CommonUtils.parseDouble(info.getSuryang());
		Double dv = CommonUtils.parseDouble(info.getDv());
		Double nalsu = CommonUtils.parseDouble(info.getNalsu());
		Double totalSuryang = CommonUtils.parseDouble(info.getTotalSuryang());
		Double currentSuryang = CommonUtils.parseDouble(info.getCurrentSuryang());
		ocs1024.setSysDate(new Date());
		ocs1024.setSysId(sysId);
		ocs1024.setUpdDate(new Date());
		ocs1024.setBunho(info.getBunho());
		ocs1024.setGwa(info.getGwa());
		ocs1024.setHangmogCode(info.getHangmogCode());
		ocs1024.setSeq(seq);
		ocs1024.setFkinp1001(info.getFkinp1001());
		ocs1024.setPkocs1024(pkocs1024);
		ocs1024.setSuryang(suryang);
		ocs1024.setOrdDanui(info.getOrdDanui());
		ocs1024.setOrderDate(info.getOrderDate());
		ocs1024.setDvTime(info.getDvTime());
		ocs1024.setDv(dv);
		ocs1024.setNalsu(nalsu);
		ocs1024.setGeneralDispYn(info.getGeneralDispYn());
		ocs1024.setBogyongCode(info.getBogyongCode());
		ocs1024.setUpdId(sysId);
		ocs1024.setHospCode(hospCode);
		ocs1024.setOrderGubun(info.getOrderGubun());
		ocs1024.setInputTab(info.getInputTab());
		ocs1024.setDrgComment(info.getDrgComment());
		ocs1024.setTotalSuryang(totalSuryang);
		ocs1024.setCurrentSuryang(currentSuryang);
		ocs1024.setInputUserId(info.getInputUserId());
		ocs1024.setJusa(info.getJusa());
		ocs1024.setJusaSpdGubun(info.getJusaSpdGubun());
		ocs1024Repository.save(ocs1024);
	}
	
	private String validationCheck(List<OCS1024U00grdOCS1024Info> grdList, String hospCode, String language){		
		if(!CollectionUtils.isEmpty(grdList)){
        	for(OCS1024U00grdOCS1024Info item : grdList){
        		boolean isDonbok = isDonbokYn(hospCode, language, item.getBogyongCode());
        		if(item.getOrderGubun().contains("C") && !isDonbok){
        			List<Drg0120> drg0120s = drg0120Repository.getObjectOBGetBogyongInfo(hospCode, item.getBogyongCode(), language);
        			if(!CollectionUtils.isEmpty(drg0120s)){
        				if(StringUtils.isEmpty(drg0120s.get(0).getBogyongGubun())){
        					return "F";
        				}
        				if(!item.getDv().equals(drg0120s.get(0).getBogyongGubun())){
        					return "TEXT_2";
        				}
        			}
        		}
        		
        	}
		}else{
			return "F";
		}
		return "T";
	}
	
	private boolean isDonbokYn(String hospCode, String language, String bogyongCode){
		List<Drg0120> drg0120s = drg0120Repository.getObjectOBGetBogyongInfo(hospCode, bogyongCode, language);
		if(!CollectionUtils.isEmpty(drg0120s)){
			if(StringUtils.isEmpty(drg0120s.get(0).getDonbogYn())){
				return false;
			}
			if("N".equals(drg0120s.get(0).getDonbogYn())){
				return false;
			}
		}else{
			return false;
		}
		return true;
	}

}
