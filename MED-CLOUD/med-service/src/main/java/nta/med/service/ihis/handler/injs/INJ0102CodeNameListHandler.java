package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.inj.Inj0102;
import nta.med.data.dao.medi.inj.Inj0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class INJ0102CodeNameListHandler extends ScreenHandler<InjsServiceProto.INJ0102CodeNameListRequest, InjsServiceProto.INJ0102CodeNameListResponse> {
	private static final Log LOG = LogFactory.getLog(INJ0102CodeNameListHandler.class);
	@Resource
	private Inj0102Repository inj0102Repository;

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ0102CodeNameListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ0102CodeNameListRequest request) throws Exception {
		InjsServiceProto.INJ0102CodeNameListResponse.Builder response = InjsServiceProto.INJ0102CodeNameListResponse.newBuilder();
		List<Inj0102> listObject = inj0102Repository.findByCodeTypeAndCode(getHospitalCode(vertx, sessionId), request.getCodeType(), request.getCode(), getLanguage(vertx, sessionId));
        if(!CollectionUtils.isEmpty(listObject)) {
        	for(Inj0102 item : listObject) {
        		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
        		if(!StringUtils.isEmpty(item.getCodeName())){
        			info.setDataValue(item.getCodeName());
        		}
        		response.addCodeNameList(info);
        	}
        }
		return response.build();
	}
}
