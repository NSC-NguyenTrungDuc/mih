package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0208Q01GrdDrg0120Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0208Q01GrdDrg0120Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0208Q01GrdDrg0120Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0208Q01GrdDrg0120Handler
	extends ScreenHandler<OcsaServiceProto.OCS0208Q01GrdDrg0120Request, OcsaServiceProto.OCS0208Q01GrdDrg0120Response> {                     
	@Resource                                                                                                       
	private Drg0120Repository drg0120Repository; 
	@Resource
	private Ocs0103Repository ocs0103Repository;
	@Resource
	private Inv0102Repository inv0102Repository;
	@Override     
	@Transactional(readOnly = true)
	public OCS0208Q01GrdDrg0120Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0208Q01GrdDrg0120Request request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0208Q01GrdDrg0120Response.Builder response = OcsaServiceProto.OCS0208Q01GrdDrg0120Response.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		String oJaeryoCode =ocs0103Repository.getOJaeryoCodeOCS0208Q01(hospCode,request.getJaeryoCode());
		List<OCS0208Q01GrdDrg0120Info> listGrd= drg0120Repository.getOCS0208Q01GrdDrg0120Info(hospCode, language, request.getChiryoGubun(),request.getBanghyang(), 
				request.getJaeryoCode(),request.getUseYn(), oJaeryoCode,request.getBogyongGubun());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(OCS0208Q01GrdDrg0120Info item : listGrd){
				OcsaModelProto.OCS0208Q01GrdDrg0120Info.Builder info = OcsaModelProto.OCS0208Q01GrdDrg0120Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdDrg0120Info(info);
			}
		}
		List<ComboListItemInfo> listCombo= inv0102Repository.getComboListItemInfoOCS0208Q01GrdDrg0120(hospCode, language);
		if(!CollectionUtils.isEmpty(listCombo)){
			for(ComboListItemInfo item : listCombo){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboInfo(info);
			}
		}
		return response.build();
	}
}