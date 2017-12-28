package nta.med.service.ihis.handler.ocsi;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01XEditGridCellRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01XEditGridCellResponse;


@Service
@Scope("prototype")
public class OCS2003P01XEditGridCellHandler  extends ScreenHandler<OcsiServiceProto.OCS2003P01XEditGridCellRequest, OcsiServiceProto.OCS2003P01XEditGridCellResponse>{

	@Resource
	private Ocs2003Repository ocs2003Repository;

	@Override
	public OCS2003P01XEditGridCellResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003P01XEditGridCellRequest request) throws Exception {
		OcsiServiceProto.OCS2003P01XEditGridCellResponse.Builder response = OcsiServiceProto.OCS2003P01XEditGridCellResponse.newBuilder();
		List<ComboListItemInfo> lst1 = ocs2003Repository.getOCS2003P01XOCS0132EditGridCell(getHospitalCode(vertx, sessionId));
		List<ComboListItemInfo> lst2 = ocs2003Repository.getOCS2003P01XBAS0260EditGridCell(getHospitalCode(vertx, sessionId),getLanguage(vertx, sessionId));
		List<ComboListItemInfo> lst3 = ocs2003Repository.getOCS2003P01XBAS0102EditGridCell(getHospitalCode(vertx, sessionId));
		
		 if(!CollectionUtils.isEmpty(lst1)){			 
			 for(ComboListItemInfo item : lst1){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addCell137(info);
					
				}
		 }
		 if(!CollectionUtils.isEmpty(lst2)){			 
			 for(ComboListItemInfo item : lst2){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addCell91(info);
					
				}
		 }
		 if(!CollectionUtils.isEmpty(lst3)){			 
			 for(ComboListItemInfo item : lst3){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addCell20(info);
					
				}
		 }
		return response.build();
	}

}
