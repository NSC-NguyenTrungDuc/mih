package nta.med.service.ihis.handler.endo;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs1801;
import nta.med.core.domain.pfe.Pfe1000;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1801Repository;
import nta.med.data.dao.medi.pfe.Pfe1000Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.EndoModelProto.END1001U02DsvDwInfo;
import nta.med.service.ihis.proto.EndoModelProto.END1001U02GrdPaStatusInfo;
import nta.med.service.ihis.proto.EndoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class END1001U02UpdateMerGrdHandler extends ScreenHandler<EndoServiceProto.END1001U02UpdateMerGrdRequest, SystemServiceProto.UpdateResponse> {                      
	private static final Log LOGGER = LogFactory.getLog(END1001U02UpdateMerGrdHandler.class);                                    
	@Resource                                                                                                       
	private Pfe1000Repository pfe1000Repository;  
	@Resource
	private Ocs1801Repository ocs1801Repository;
	                                                                                                                
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			EndoServiceProto.END1001U02UpdateMerGrdRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		Double fkocs = CommonUtils.parseDouble(request.getFkOcs());
		String updId = request.getUpdId();
		String residentYn = request.getResidentYn();
		Integer result = null;
		
		//for END1001U02DsvDwInfo           
		List<String> getYInPfe1000 = pfe1000Repository.getYByHospCodeAndFk0cs(hospCode, fkocs);
		if(!CollectionUtils.isEmpty(getYInPfe1000)){
			List<END1001U02DsvDwInfo> listDsvDw = request.getDsvdwObjList();
			if(!CollectionUtils.isEmpty(listDsvDw)){
				for(END1001U02DsvDwInfo item : listDsvDw){
					result = pfe1000Repository.updatePfe1000ByHospCodeAndFkocs(hospCode, fkocs, updId, item.getC3(), item.getBunho(), item.getHangmogCode(), residentYn);
					if(result <= 0){
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
				}
			}
		}else{
			Double retSeq = pfe1000Repository.getMaxPKPFE1000ByHospCode(hospCode);
			Pfe1000 pfe100 = new Pfe1000();
			pfe100.setSysDate(new Date());
			pfe100.setUpdId(updId);
			pfe100.setUpdDate(new Date());
			pfe100.setPkpfe1000(retSeq);
			pfe100.setC3(request.getC3());
			pfe100.setFkocs(fkocs);
			pfe100.setBunho(request.getBunho());
			pfe100.setHangmogCode(request.getHangmogCode());
			pfe100.setResidentYn(residentYn);
			pfe100.setHospCode(hospCode);
			pfe1000Repository.save(pfe100);
		}
		
		//for END1001U02DsvDwInfo
		List<END1001U02GrdPaStatusInfo> listGrdPasStatus = request.getGrdpaStatusObjList();
		if(!CollectionUtils.isEmpty(listGrdPasStatus)){
			for(END1001U02GrdPaStatusInfo item : listGrdPasStatus){
				List<String> getYInOcs1081 = ocs1801Repository.getCheckY(hospCode, item.getPatStatus(), request.getBunho());
				Double seq = CommonUtils.parseDouble(item.getSeq());
				if(!CollectionUtils.isEmpty(getYInOcs1081)){
					result = ocs1801Repository.updateOcs1801(hospCode, updId, item.getPatStatus(), item.getPatStatusCode(), item.getMent(), seq, request.getBunho());
					if(result <= 0){
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
				}else{
					Ocs1801 ocs1801 = new Ocs1801();
					ocs1801.setSysDate(new Date());
					ocs1801.setUpdId(updId);
					ocs1801.setUpdDate(new Date());
					ocs1801.setBunho(request.getBunho());
					ocs1801.setPatStatus(item.getPatStatus());
					ocs1801.setPatStatusCode(item.getPatStatusCode());
					ocs1801.setMent(item.getMent());
					ocs1801.setSeq(seq);
					ocs1801.setHospCode(hospCode);
					ocs1801Repository.save(ocs1801);
				}
			}
		}
		response.setResult(true);
		return response.build();
	}
	
}