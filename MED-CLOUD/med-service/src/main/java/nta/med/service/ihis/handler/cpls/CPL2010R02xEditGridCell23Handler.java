package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010R02xEditGridCell23Request;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010R02xEditGridCell23Response;

@Service                                                                                                          
@Scope("prototype") 
public class CPL2010R02xEditGridCell23Handler extends ScreenHandler<CplsServiceProto.CPL2010R02xEditGridCell23Request, CplsServiceProto.CPL2010R02xEditGridCell23Response>{
	@Resource
	private Bas0102Repository bas0102Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public CPL2010R02xEditGridCell23Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL2010R02xEditGridCell23Request request) throws Exception {
		CplsServiceProto.CPL2010R02xEditGridCell23Response.Builder response = CplsServiceProto.CPL2010R02xEditGridCell23Response.newBuilder();
		List<ComboListItemInfo> list = bas0102Repository.getComboListItemInfoByCodeType(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "IN_OUT_GUBUN");
		if (!CollectionUtils.isEmpty(list)) {
			for (ComboListItemInfo item : list) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addXeditItem(info);
			}
		}
		return response.build();
	}

}
