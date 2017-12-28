package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.CboDoctorGradeRequest;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CboDoctorGradeHandler
	extends ScreenHandler<SystemServiceProto.CboDoctorGradeRequest, SystemServiceProto.ComboResponse> {
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, CboDoctorGradeRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		List<ComboListItemInfo> listResult = bas0102Repository.getCodeNameListItem(request.getHospCode(), request.getCodeType(), "1", getLanguage(vertx, sessionId));
		if(listResult != null && !listResult.isEmpty()){
			for(ComboListItemInfo item : listResult){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getCode())) {
					info.setCode(item.getCode());
				}
				if (!StringUtils.isEmpty(item.getCodeName())) {
					info.setCodeName("("+item.getCode()+") "+item.getCodeName());
				}
				response.addComboItem(info);
			}
		}
		return response.build();
	}
}
