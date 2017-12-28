package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out2016Repository;
import nta.med.data.model.ihis.nuro.NUR2016U02GrdListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.NUR2016U02GrdListRequest;
import nta.med.service.ihis.proto.NuroServiceProto.NUR2016U02GrdListResponse;

@Service
@Scope("prototype")
public class NUR2016U02GrdListHandler extends ScreenHandler<NuroServiceProto.NUR2016U02GrdListRequest, NuroServiceProto.NUR2016U02GrdListResponse>{
	private static final Log logger = LogFactory.getLog(NUR2016U02GrdListHandler.class);
	
	@Resource
	private Out2016Repository out2016Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR2016U02GrdListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2016U02GrdListRequest request) throws Exception {
		NuroServiceProto.NUR2016U02GrdListResponse.Builder response = NuroServiceProto.NUR2016U02GrdListResponse.newBuilder();
		List<NUR2016U02GrdListInfo> listGrd = out2016Repository.getNUR2016U02GrdListInfo(getHospitalCode(vertx, sessionId), request.getBunho());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(NUR2016U02GrdListInfo item : listGrd){
				NuroModelProto.NUR2016U02GrdListInfo.Builder info = NuroModelProto.NUR2016U02GrdListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdItem(info);
			}
		}
		return response.build();
	}

}
