package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2020Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service
@Scope("prototype")
public class DrgsDRG5100P01MakeBongtuOutHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01MakeBongtuOutRequest, DrgsServiceProto.DrgsDRG5100P01MakeBongtuOutResponse> {
	private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01MakeBongtuOutHandler.class);
	@Resource
	private Drg2020Repository drg2020Repository;

	@Override
	public boolean isValid(DrgsServiceProto.DrgsDRG5100P01MakeBongtuOutRequest request, Vertx vertx, String clientId, String sessionId) {
		try {
			Integer.parseInt(request.getIDrgBunho());
		} catch (NumberFormatException e) {
			return false;
		}
		if(!StringUtils.isEmpty(request.getISysDate()) && DateUtil.toDate(request.getISysDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		} else if(!StringUtils.isEmpty(request.getIOrderDate()) && DateUtil.toDate(request.getIOrderDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		} else if(!StringUtils.isEmpty(request.getIJubsuDate()) && DateUtil.toDate(request.getIJubsuDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		}
		return true;
	}

	@Override
	public DrgsServiceProto.DrgsDRG5100P01MakeBongtuOutResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01MakeBongtuOutRequest request) throws Exception {
		DrgsServiceProto.DrgsDRG5100P01MakeBongtuOutResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01MakeBongtuOutResponse.newBuilder();
		Integer drgBunho = Integer.parseInt(request.getIDrgBunho());
		String result = drg2020Repository.callPrDrgMakeBongtuOut(DateUtil.toDate(request.getISysDate(), DateUtil.PATTERN_YYMMDD), request.getIUserId(),
				DateUtil.toDate(request.getIOrderDate(), DateUtil.PATTERN_YYMMDD), DateUtil.toDate(request.getIJubsuDate(), DateUtil.PATTERN_YYMMDD),
				request.getIJubsuTime(), drgBunho, request.getIWonyoiOrderYn(), request.getIJubsuYn(), request.getIGyunbonYn(), getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		LOG.info("callPrDrgMakeBongtuOut O_ERR=" + result);
		response.setResult(true);
		return response.build();
	}
}
