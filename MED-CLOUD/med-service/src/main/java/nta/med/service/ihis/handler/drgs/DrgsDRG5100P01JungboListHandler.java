package nta.med.service.ihis.handler.drgs;

import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01JungboListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service
@Scope("prototype")
public class DrgsDRG5100P01JungboListHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01JungboListRequest, DrgsServiceProto.DrgsDRG5100P01JungboListResponse> {
	private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01JungboListHandler.class);
	@Resource
	private Drg2010Repository drg2010Repository;

	@Override
	@Transactional(readOnly = true)
	public DrgsServiceProto.DrgsDRG5100P01JungboListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01JungboListRequest request) throws Exception {
		DrgsDRG5100P01JungboListInfo object = drg2010Repository.getDrgsDRG5100P01JungboListInfo(getHospitalCode(vertx, sessionId), request.getBunho(), request.getComments());
		DrgsServiceProto.DrgsDRG5100P01JungboListResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01JungboListResponse.newBuilder();
		if(object != null) {
			if (!StringUtils.isEmpty(object.getHeight())) {
				response.setHeight(object.getHeight());
			}
			if (!StringUtils.isEmpty(object.getCm())) {
				response.setCm(object.getCm());
			}
			if (!StringUtils.isEmpty(object.getWeight())) {
				response.setWeight(object.getWeight());
			}
			if (!StringUtils.isEmpty(object.getKg())) {
				response.setKg(object.getKg());
			}
			if (!StringUtils.isEmpty(object.getCplResult())) {
				response.setCplResult(object.getCplResult());
			}
			if (!StringUtils.isEmpty(object.getComments())) {
				response.setComments(object.getComments());
			}
			if (!StringUtils.isEmpty(object.getCnt())) {
				response.setCnt(object.getCnt().toString());
			}
		}
		return response.build();
	}
}
