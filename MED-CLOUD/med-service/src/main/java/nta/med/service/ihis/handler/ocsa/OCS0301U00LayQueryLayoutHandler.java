package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0303Repository;
import nta.med.data.model.ihis.ocsa.OCS0301U00LayoutInfo;
import nta.med.data.model.ihis.ocsa.OCS0307U00GrdListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301U00LayQueryLayoutRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301U00LayQueryLayoutResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0301U00LayQueryLayoutHandler
	extends ScreenHandler<OcsaServiceProto.OCS0301U00LayQueryLayoutRequest, OcsaServiceProto.OCS0301U00LayQueryLayoutResponse>{                     
	@Resource                                                                                                       
	private Ocs0303Repository ocs0303Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0301U00LayQueryLayoutRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override            
	@Transactional(readOnly = true)
	public OCS0301U00LayQueryLayoutResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0301U00LayQueryLayoutRequest request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0301U00LayQueryLayoutResponse.Builder response = OcsaServiceProto.OCS0301U00LayQueryLayoutResponse.newBuilder();  
  	   	//repeated OCS0301U00LayoutInfo layout_info = 1
		List<OCS0301U00LayoutInfo> listOCS0301U00LayoutInfo = ocs0303Repository.getOCS0301U00LayoutInfo(request.getHospCode(), getLanguage(vertx, sessionId), request.getMemb(),CommonUtils.parseDouble(request.getFkocs0300Seq()), request.getYaksokCode());
		if(!CollectionUtils.isEmpty(listOCS0301U00LayoutInfo)){
			for(OCS0301U00LayoutInfo item : listOCS0301U00LayoutInfo){
				OcsaModelProto.OCS0301U00LayoutInfo.Builder info = OcsaModelProto.OCS0301U00LayoutInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getInOutKey() != null) {
					info.setInOutKey(String.format("%.0f",item.getInOutKey()));
				}
				if (item.getPkocskey() != null) {
					info.setPkocskey(String.format("%.0f",item.getPkocskey()));
				}
				if (item.getGroupSer() != null) {
					info.setGroupSer(String.format("%.0f",item.getGroupSer()));
				}
				if (item.getSeq() != null) {
					info.setSeq(String.format("%.0f",item.getSeq()));
				}
				if (item.getSuryang() != null) {
					info.setSuryang(String.format("%.0f",item.getSuryang()));
				}
				if (item.getSunabSuryang() != null) {
					info.setSunabSuryang(String.format("%.0f",item.getSunabSuryang()));
				}
				if (item.getSubulSuryang() != null) {
					info.setSubulSuryang(String.format("%.0f",item.getSubulSuryang()));
				}
				if (item.getDv() != null) {
					info.setDv(String.format("%.0f",item.getDv()));
				}
				if (item.getDv1() != null) {
					info.setDv1(String.format("%.0f",item.getDv1()));
				}
				if (item.getDv2() != null) {
					info.setDv2(String.format("%.0f",item.getDv2()));
				}
				if (item.getDv3() != null) {
					info.setDv3(String.format("%.0f",item.getDv3()));
				}
				if (item.getDv4() != null) {
					info.setDv4(String.format("%.0f",item.getDv4()));
				}
				if (item.getNalsu() != null) {
					info.setNalsu(String.format("%.0f",item.getNalsu()));
				}
				if (item.getAmt() != null) {
					info.setAmt(String.format("%.0f",item.getAmt()));
				}
				if (item.getBomSourceKey() != null) {
					info.setBomSourceKey(String.format("%.0f",item.getBomSourceKey()));
				}
				if (item.getOrgKey() != null) {
					info.setOrgKey(String.format("%.0f",item.getOrgKey()));
				}
				if (item.getParentKey() != null) {
					info.setParentKey(String.format("%.0f",item.getParentKey()));
				}
				response.addLayoutInfo(info);
			}
		}
		
		//repeat combolistiteminfo = 2;
		List<OCS0307U00GrdListItemInfo> listCombo0307Info = ocs0303Repository.getComboList0307Info(getHospitalCode(vertx, sessionId), request.getMemb(), request.getFkocs0300Seq(), request.getYaksokCode());
		if (!CollectionUtils.isEmpty(listCombo0307Info)) {
			for (OCS0307U00GrdListItemInfo item : listCombo0307Info) {
				OcsaModelProto.OCS0301U00Membgrd307Info.Builder info = OcsaModelProto.OCS0301U00Membgrd307Info.newBuilder();
				info.setSangCode(item.getSangCode());
				info.setSangName(item.getSangName());
				info.setPkocs0307(item.getPkocs0307().toString());
//				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListInfo(info);
			}
		}
		
		return response.build();	
	}                                                                                                                                                   
}																																						

