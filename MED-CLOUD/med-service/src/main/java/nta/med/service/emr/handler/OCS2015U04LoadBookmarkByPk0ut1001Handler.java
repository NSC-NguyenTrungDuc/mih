package nta.med.service.emr.handler;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.emr.EmrBookmarkRepository;
import nta.med.data.model.ihis.emr.OCS2015U04LoadBookmarkByPk0ut1001Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS2015U04LoadBookmarkByPk0ut1001Handler extends ScreenHandler<EmrServiceProto.OCS2015U04LoadBookmarkByPk0ut1001Request, EmrServiceProto.OCS2015U04LoadBookmarkByPk0ut1001Response> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U04LoadBookmarkByPk0ut1001Handler.class);                                    
	@Resource                                                                                                       
	private EmrBookmarkRepository emrBookmarkRepository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U04LoadBookmarkByPk0ut1001Response handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U04LoadBookmarkByPk0ut1001Request request) throws Exception {
		EmrServiceProto.OCS2015U04LoadBookmarkByPk0ut1001Response.Builder response = EmrServiceProto.OCS2015U04LoadBookmarkByPk0ut1001Response.newBuilder();
		List<OCS2015U04LoadBookmarkByPk0ut1001Info> list = emrBookmarkRepository.getOCS2015U04LoadBookmarkByPk0ut1001Info(request.getPkout1001(), request.getSysId(), request.getEmrRecordId());
		if(!CollectionUtils.isEmpty(list)) {
			for (OCS2015U04LoadBookmarkByPk0ut1001Info item:list){
				EmrModelProto.OCS2015U04LoadBookmarkByPk0ut1001Info.Builder info = EmrModelProto.OCS2015U04LoadBookmarkByPk0ut1001Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				info.setPkout1001(String.format("%.0f", item.getPkout1001()));
				response.addEmrOneBookmarkList(info);
			}
		}
		return response.build();
	}
}