package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0272Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OFFormSetMakeFormLoadRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OFFormSetMakeFormLoadResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OFFormSetMakeFormLoadHandler extends ScreenHandler <SystemServiceProto.OFFormSetMakeFormLoadRequest, SystemServiceProto.OFFormSetMakeFormLoadResponse> {                     
	@Resource                                                                                                       
	private Adm3200Repository adm3200Repository;                                                                   
	@Resource                                                                                                       
	private Bas0272Repository bas0272Repository; 
	
	@Override
	@Transactional(readOnly = true)
	public OFFormSetMakeFormLoadResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OFFormSetMakeFormLoadRequest request) throws Exception{                                                                   
      	   	SystemServiceProto.OFFormSetMakeFormLoadResponse.Builder response = SystemServiceProto.OFFormSetMakeFormLoadResponse.newBuilder();     
	  	String hospCode = getHospitalCode(vertx, sessionId);
	  	String language = getLanguage(vertx, sessionId);
		//OFMakeUserComboRequest
		List<ComboListItemInfo> listMakerUser=adm3200Repository.getOFMakeUserCombo(hospCode,"",request.getIsDoctorMode());
		if(!CollectionUtils.isEmpty(listMakerUser)){
			for(ComboListItemInfo item:listMakerUser){
				CommonModelProto.ComboListItemInfo.Builder info= CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addUserComboItem(info);
			}
		}
		//OFMakeGwaComboRequest
		List<ComboListItemInfo> listMakeGwa=bas0272Repository.getOFMakeGwaCombo(hospCode, language,request.getSabun());
		if(!CollectionUtils.isEmpty(listMakeGwa)){
			for(ComboListItemInfo item:listMakeGwa){
				CommonModelProto.ComboListItemInfo.Builder info= CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGwaComboItem(info);
			}
		}
		//OFMakeTreeViewRequest
//				List<OFMakeTreeViewInfo> listMakeTree=ocs0300Repository.getOFMakeTreeView(hospCode,request.getMemb(),request.getInputTab());
//				if(!CollectionUtils.isEmpty(listMakeTree)){
//					for(OFMakeTreeViewInfo item : listMakeTree){
//						CommonModelProto.OFMakeTreeViewInfo.Builder info=CommonModelProto.OFMakeTreeViewInfo.newBuilder();
//						BeanUtils.copyProperties(item, info);
//						response.addTreeViewItem(info);
//					}
//				}
		return response.build();
	}
}