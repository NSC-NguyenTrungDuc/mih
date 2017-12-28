package nta.med.service.ihis.handler.ocso;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs1023;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs1023Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto.OCS1023U00GrdOCS1023Info;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS1023U00SaveLayoutHandler extends ScreenHandler<OcsoServiceProto.OCS1023U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS1023U00SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private CommonRepository commonRepository;                                                                    
	@Resource                                                                                                       
	private Ocs1023Repository ocs1023Repository;                                                                    
	                                                                                                                
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS1023U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder(); 
		String hospCode = getHospitalCode(vertx, sessionId);
		String mSeq = commonRepository.getNextVal("OCS1023_SEQ");
		if(StringUtils.isEmpty(mSeq)){
			response.setResult(false);
			throw new ExecutionException(response.build());
		}
		if(CollectionUtils.isEmpty(request.getInputListList())){
			response.setResult(false);
			throw new ExecutionException(response.build());
		}else{
			boolean save = false;
			for(OCS1023U00GrdOCS1023Info item : request.getInputListList()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					save = insertOcs1023(item, request.getUserId(), hospCode);
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					save = updateOcs1023(item, request.getUserId(), hospCode);
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if(ocs1023Repository.deleteOcs1023U00(CommonUtils.parseDouble(item.getPkocs1023()), hospCode) <= 0){
						save = false;
					}
				}
			}
			if(!save){
				response.setResult(false);
				throw new ExecutionException(response.build());
			}
		}
		
		response.setResult(true);
		return response.build();
	}
	
	private boolean insertOcs1023(OCS1023U00GrdOCS1023Info item, String userId, String hospCode){
		Ocs1023 ocs1023 = new Ocs1023();
		ocs1023.setSysDate(new Date());
		ocs1023.setSysId(userId);
		ocs1023.setUpdDate(new Date());
		ocs1023.setBunho(item.getBunho());
		ocs1023.setGwa(item.getGwa());
		ocs1023.setHangmogCode(item.getHangmogCode());
		ocs1023.setSeq(CommonUtils.parseDouble(item.getSeq()));
		ocs1023.setPkocs1023(CommonUtils.parseDouble(item.getPkocs1023()));
		ocs1023.setSpecimenCode(item.getSpecimenCode());
		ocs1023.setSuryang(CommonUtils.parseDouble(item.getSuryang()));
		ocs1023.setOrdDanui(item.getOrdDanui());
		ocs1023.setDvTime(item.getDvTime());
		ocs1023.setDv(CommonUtils.parseDouble(item.getDv()));
		ocs1023.setNalsu(CommonUtils.parseDouble(item.getNalsu()));
		ocs1023.setJusa(item.getJusa());
		ocs1023.setBogyongCode(item.getBogyongCode());
		ocs1023.setPortableYn(item.getPortableCrYn());
		ocs1023.setAntiCancerYn(item.getAntiCancerCrYn());
		ocs1023.setPowderYn(item.getPowderYn());
		ocs1023.setDv1(CommonUtils.parseDouble(item.getDv1()));
		ocs1023.setDv2(CommonUtils.parseDouble(item.getDv2()));
		ocs1023.setDv3(CommonUtils.parseDouble(item.getDv3()));
		ocs1023.setDv4(CommonUtils.parseDouble(item.getDv4()));
		ocs1023.setUpdId(userId);
		ocs1023.setHospCode(hospCode);
		ocs1023Repository.save(ocs1023);
		return true;
	}
	
	private boolean updateOcs1023(OCS1023U00GrdOCS1023Info item, String userId, String hospCode){
		if(ocs1023Repository.updateOcs1023U00(
				userId,
				new Date(),
				CommonUtils.parseDouble(item.getSeq()),
				item.getSpecimenCode(),
				CommonUtils.parseDouble(item.getSuryang()),
				item.getOrdDanui(),
				item.getDvTime(),
				CommonUtils.parseDouble(item.getDv()),
				CommonUtils.parseDouble(item.getDv1()),
				CommonUtils.parseDouble(item.getDv2()),
				CommonUtils.parseDouble(item.getDv3()),
				CommonUtils.parseDouble(item.getDv4()),
				CommonUtils.parseDouble(item.getNalsu()),
				item.getJusa(),
				item.getBogyongCode(),
				item.getPortableYn(),
				item.getAntiCancerYn(),
				item.getPowderYn(),
				CommonUtils.parseDouble(item.getPkocs1023()),
				hospCode) > 0){
			return true;
		}else{
			return false;
		}
	}
	
}