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
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.bass.LoadDepartmentTypeInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01EtcIpwonxEditGridCellRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01EtcIpwonxEditGridCellResponse;

@Service                                                                                                          
@Scope("prototype")  
public class INP1001U01EtcIpwonxEditGridCellHandler extends ScreenHandler<InpsServiceProto.INP1001U01EtcIpwonxEditGridCellRequest, InpsServiceProto.INP1001U01EtcIpwonxEditGridCellResponse>{
	@Resource
	private Bas0260Repository bas0260Repository;
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP1001U01EtcIpwonxEditGridCellResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, INP1001U01EtcIpwonxEditGridCellRequest request) throws Exception {
		InpsServiceProto.INP1001U01EtcIpwonxEditGridCellResponse.Builder response = InpsServiceProto.INP1001U01EtcIpwonxEditGridCellResponse.newBuilder();
		List<ComboListItemInfo> list3 = bas0260Repository.getComboDepartmentItemInfo(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), null, false);
		if (!CollectionUtils.isEmpty(list3)) {
			for (ComboListItemInfo item : list3) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				info.setCode(item.getCode());
				info.setCodeName(item.getCodeName());
				response.addXEditGridCell3(info);
			}
		}
		
		List<LoadDepartmentTypeInfo> list5 = bas0102Repository.getDepartmentTypeInfo(getHospitalCode(vertx, sessionId), "IPWON_TYPE", getLanguage(vertx, sessionId));
		if (!CollectionUtils.isEmpty(list5)) {
			for (LoadDepartmentTypeInfo item : list5) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				info.setCode(item.getCode());
				info.setCodeName(item.getCodeName());
				response.addXEditGridCell5(info);
			}
		}
		return response.build();
	}

}
