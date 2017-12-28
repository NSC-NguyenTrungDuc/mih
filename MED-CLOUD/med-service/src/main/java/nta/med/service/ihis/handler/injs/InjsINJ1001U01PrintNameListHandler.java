package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.adm.Adm3300;
import nta.med.data.dao.medi.adm.Adm3300Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class InjsINJ1001U01PrintNameListHandler extends ScreenHandler<InjsServiceProto.InjsINJ1001U01PrintNameListRequest, InjsServiceProto.InjsINJ1001U01PrintNameListResponse> {
	private static final Log LOG = LogFactory.getLog(InjsINJ1001U01PrintNameListHandler.class);
	@Resource
	private Adm3300Repository adm3300Repository;

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.InjsINJ1001U01PrintNameListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.InjsINJ1001U01PrintNameListRequest request) throws Exception {
		InjsServiceProto.InjsINJ1001U01PrintNameListResponse.Builder response = InjsServiceProto.InjsINJ1001U01PrintNameListResponse.newBuilder();
		List<Adm3300> listResult = adm3300Repository.findByIpAddr(getHospitalCode(vertx, sessionId), request.getIpAddr());
        if (!CollectionUtils.isEmpty(listResult)) {
        	for (Adm3300 item : listResult) {
	            if (!StringUtils.isEmpty(item.getBPrintName())) {
            		response.addPrintNameList(item.getBPrintName());
            	}
        	}
        }
		return response.build();
	}
}
