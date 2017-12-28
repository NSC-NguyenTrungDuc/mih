package nta.med.service.ihis.handler.cpls;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0001Repository;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0101U00MakeFindWorkerRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.apache.commons.lang.ArrayUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL0101U00MakeFindWorkerHandler extends ScreenHandler<CplsServiceProto.CPL0101U00MakeFindWorkerRequest, SystemServiceProto.ComboResponse> {
	private static final Log LOGGER = LogFactory.getLog(CPL0101U00MakeFindWorkerHandler.class);
	@Resource
	private Cpl0109Repository cpl0109Repository;
	@Resource
	private Cpl0101Repository cpl0101Repository;
	@Resource
	private Cpl0001Repository cpl0001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, CPL0101U00MakeFindWorkerRequest request)
					throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String[] aCtrName = {"fbxSpecimenCode","fbxDanui","fbxTubeCode","fbxUitakCode","fbxSutakCode","fbxJangbiCode","fbxJangbiCode2","fbxJangbiCode3"}; 
		List<ComboListItemInfo> listResult = new  ArrayList<ComboListItemInfo>();
		if(request.getACtrName().equals("fbxHangmogCode")){
			listResult = cpl0101Repository.getCPL0101U00FbxHangmogCodeComboListItem(hospitalCode, request.getFind1(), request.getFind2());
		} else if(request.getACtrName().equals("fbxJundalGubun")){
			listResult = cpl0109Repository.getCPL0101U00FbxJundalGubunComboListItem(hospitalCode, request.getCodeType(),"CPL",request.getFind1(),request.getFind2(),language);
		}else if(request.getACtrName().equals("fbxSlipCode")){
			listResult = cpl0001Repository.getCPL0101U00FbxSlipCodeComboListItem(hospitalCode, request.getFind1(), request.getFind2(), language);
		}else if(ArrayUtils.contains(aCtrName,request.getACtrName())){
			listResult = cpl0109Repository.getCPL0101U00getACtrComboListItem(hospitalCode, request.getCodeType(),request.getFind1(),request.getFind2(),language);
		} 
		if(listResult != null && !listResult.isEmpty()){
			for(ComboListItemInfo item :listResult){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getCode())) {
					info.setCode(item.getCode());
				}
				if (!StringUtils.isEmpty(item.getCodeName())) {
					info.setCodeName(item.getCodeName());
				}
				response.addComboItem(info);
			}
		}
		return response.build();
	}
}
