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
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q01fwkHangmogCodeRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q01fwkHangmogCodeResponse;

@Service                                                                                                          
@Scope("prototype") 
public class CPL0000Q01fwkHangmogCodeHandler extends ScreenHandler<CplsServiceProto.CPL0000Q01fwkHangmogCodeRequest, CplsServiceProto.CPL0000Q01fwkHangmogCodeResponse>{
	@Resource
	private Cpl0101Repository cpl0101Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public CPL0000Q01fwkHangmogCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL0000Q01fwkHangmogCodeRequest request) throws Exception {
		CplsServiceProto.CPL0000Q01fwkHangmogCodeResponse.Builder response = CplsServiceProto.CPL0000Q01fwkHangmogCodeResponse.newBuilder();
		List<ComboListItemInfo> list = cpl0101Repository.getCPL0000Q01fwkHangmogCode(getHospitalCode(vertx, sessionId), request.getFind1(), request.getFind2());
		if (!CollectionUtils.isEmpty(list)) {
			for (ComboListItemInfo item : list) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addFwkItem(info);
			}
		}
		return response.build();
	}

}
