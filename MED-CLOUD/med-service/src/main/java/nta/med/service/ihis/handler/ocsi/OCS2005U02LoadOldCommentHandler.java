package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02LoadOldCommentRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02LoadOldCommentResponse;

@Service
@Scope("prototype")
public class OCS2005U02LoadOldCommentHandler extends
		ScreenHandler<OcsiServiceProto.OCS2005U02LoadOldCommentRequest, OcsiServiceProto.OCS2005U02LoadOldCommentResponse> {

	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Resource
	private Inp1003Repository inp1003Repository;
	
	// UNDONE
	@Override
	@Transactional(readOnly=true)
	public OCS2005U02LoadOldCommentResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02LoadOldCommentRequest request) throws Exception {
		OcsiServiceProto.OCS2005U02LoadOldCommentResponse.Builder response = OcsiServiceProto.OCS2005U02LoadOldCommentResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String fkinp1001 = "0";
		
		List<DataStringListItemInfo> result = inp1001Repository.getPkInp1001Ocs2005U02(hospCode, request.getBunho(), request.getMpressedJYN());
		if(CollectionUtils.isEmpty(result)){
			result = inp1003Repository.OCS2005U02getReserFkInp1001(hospCode, request.getBunho(), "0");
		}
		
		if(CollectionUtils.isEmpty(result)){
			fkinp1001 ="0";
		}else{
			for(DataStringListItemInfo item : result){
				fkinp1001 = item.getItem();
			}
		}	
				
		List<ComboListItemInfo> result1 = ocs2005Repository.OCS2005U02btnLoadOldComment(hospCode, request.getBldGubun(), CommonUtils.parseDouble(fkinp1001));
		if(!CollectionUtils.isEmpty(result1)){
			for(ComboListItemInfo item : result1){
				if(fkinp1001.equals("0"))
					item.setCode("0");
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				info.setCode(item.getCode());
				info.setCodeName(item.getCodeName());
				response.setObjItem(info);
			}
		}else{
			ComboListItemInfo item = new ComboListItemInfo("0","");
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
			info.setCode(item.getCode());
			info.setCodeName(item.getCodeName());
			response.setObjItem(info);
		}
		
		return response.build();
	}

	
}
