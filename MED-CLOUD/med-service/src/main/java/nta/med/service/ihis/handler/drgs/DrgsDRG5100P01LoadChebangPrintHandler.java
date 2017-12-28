package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01LoadChebangPrintInfo;
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
public class DrgsDRG5100P01LoadChebangPrintHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01LoadChebangPrintRequest, DrgsServiceProto.DrgsDRG5100P01LoadChebangPrintResponse> {
	private static final Log LOGGER = LogFactory.getLog(DrgsDRG5100P01LoadChebangPrintHandler.class);
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional
	public DrgsServiceProto.DrgsDRG5100P01LoadChebangPrintResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01LoadChebangPrintRequest request) throws Exception {
		Double fkOut1001 = CommonUtils.parseDouble(request.getOFkocs1003());
		DrgsDRG5100P01LoadChebangPrintInfo info= out1001Repository.getDrgsDRG5100P01LoadChebangPrintInfo(getHospitalCode(vertx, sessionId), fkOut1001);

		DrgsServiceProto.DrgsDRG5100P01LoadChebangPrintResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01LoadChebangPrintResponse.newBuilder();
		if(info != null){
			if (!StringUtils.isEmpty(info.getoGubunName())) {
				response.setOGubunName(info.getoGubunName());
			}
			if (!StringUtils.isEmpty(info.getoJohap())) {
				response.setOJohap(info.getoJohap());
			}
			if (!StringUtils.isEmpty(info.getoGaein())) {
				response.setOGaein(info.getoGaein());
			}
			if (!StringUtils.isEmpty(info.getoGaeinNo())) {
				response.setOGaeinNo(info.getoGaeinNo());
			}
			if (!StringUtils.isEmpty(info.getoBoninGubun())) {
				response.setOBoninGubun(info.getoBoninGubun());
			}
			if (!StringUtils.isEmpty(info.getoBonRate())) {
				response.setOBonRate(info.getoBonRate());
			}
			if (!StringUtils.isEmpty(info.getoBudamjaBunho1())) {
				response.setOBudamjaBunho1(info.getoBudamjaBunho1());
			}
			if (!StringUtils.isEmpty(info.getoSugubjaBunho1())) {
				response.setOSugubjaBunho1(info.getoSugubjaBunho1());
			}
			if (!StringUtils.isEmpty(info.getoBudamjaBunho2())) {
				response.setOBudamjaBunho2(info.getoBudamjaBunho2());
			}
			if (!StringUtils.isEmpty(info.getoSugubjaBunho2())) {
				response.setOSugubjaBunho2(info.getoSugubjaBunho2());
			}
			if (!StringUtils.isEmpty(info.getoSunwonGubun())) {
				response.setOSunwonGubun(info.getoSunwonGubun());
			}
			if (!StringUtils.isEmpty(info.getoNoinRateName())) {
				response.setONoinRateName(info.getoNoinRateName());
			}
			if (!StringUtils.isEmpty(info.getoErr())) {
				response.setOErr(info.getoErr());
			}
		}
		return response.build();
	}
}
