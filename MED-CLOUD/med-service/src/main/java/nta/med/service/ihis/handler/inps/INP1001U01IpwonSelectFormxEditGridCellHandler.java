package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.bass.LoadDepartmentTypeInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01IpwonSelectFormxEditGridCellRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01IpwonSelectFormxEditGridCellResponse;

@Service                                                                                                          
@Scope("prototype")
public class INP1001U01IpwonSelectFormxEditGridCellHandler extends ScreenHandler<InpsServiceProto.INP1001U01IpwonSelectFormxEditGridCellRequest, InpsServiceProto.INP1001U01IpwonSelectFormxEditGridCellResponse>{
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP1001U01IpwonSelectFormxEditGridCellResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, INP1001U01IpwonSelectFormxEditGridCellRequest request) throws Exception {
		InpsServiceProto.INP1001U01IpwonSelectFormxEditGridCellResponse.Builder response = InpsServiceProto.INP1001U01IpwonSelectFormxEditGridCellResponse.newBuilder();
		List<LoadDepartmentTypeInfo> list = bas0102Repository.getDepartmentTypeInfo(getHospitalCode(vertx, sessionId), "IPWON_TYPE", getLanguage(vertx, sessionId));
		if (!CollectionUtils.isEmpty(list)) {
			for (LoadDepartmentTypeInfo item : list) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				info.setCode(item.getCode());
				info.setCodeName(item.getCodeName());
				response.addCboItem(info);
			}
		}
		return response.build();
	}

}
