package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01GridReserOrderListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsoOCS1003P01GridReserOrderListHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01GridReserOrderListRequest, OcsoServiceProto.OcsoOCS1003P01GridReserOrderListResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01GridReserOrderListHandler.class);

	@Resource
	private Ocs0103Repository ocs0103Repository;
	
	@Override
	public boolean isValid(OcsoServiceProto.OcsoOCS1003P01GridReserOrderListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01GridReserOrderListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01GridReserOrderListRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01GridReserOrderListResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01GridReserOrderListResponse.newBuilder();
		List<OcsoOCS1003P01GridReserOrderListInfo> listObject = ocs0103Repository.getOcsoOCS1003P01GridReserOrderList(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), request.getBunho(), request.getNaewonDate());
		if (listObject != null && !listObject.isEmpty()) {
			for (OcsoOCS1003P01GridReserOrderListInfo obj : listObject) {
				OcsoModelProto.OcsoOCS1003P01GridReserOrderListInfo.Builder itemBuilder = OcsoModelProto.OcsoOCS1003P01GridReserOrderListInfo.newBuilder();
				if (!StringUtils.isEmpty(obj.getKizyunDate())) {
					itemBuilder.setKizyunDate(obj.getKizyunDate().toString());
				}
				if (!StringUtils.isEmpty(obj.getGwa())) {
					itemBuilder.setGwa(obj.getGwa());
				}
				if (!StringUtils.isEmpty(obj.getGwaName())) {
					itemBuilder.setGwaName(obj.getGwaName());
				}
				if (!StringUtils.isEmpty(obj.getDoctor())) {
					itemBuilder.setDoctor(obj.getDoctor());
				}
				if (!StringUtils.isEmpty(obj.getDoctorName())) {
					itemBuilder.setDoctorName(obj.getDoctorName());
				}
				//
				if (!StringUtils.isEmpty(obj.getHangmogCode())) {
					itemBuilder.setHangmogCode(obj.getHangmogCode());
				}
				if (!StringUtils.isEmpty(obj.getHangmogName())) {
					itemBuilder.setHangmogName(obj.getHangmogName());
				}
				if (!StringUtils.isEmpty(obj.getJundalTable())) {
					itemBuilder.setJundalTable(obj.getJundalTable());
				}
				if (!StringUtils.isEmpty(obj.getJundalPart())) {
					itemBuilder.setJundalPart(obj.getJundalPart());
				}
				if (!StringUtils.isEmpty(obj.getJundalPartName())) {
					itemBuilder.setJundalPartName(obj.getJundalPartName());
				}//
				if (!StringUtils.isEmpty(obj.getReserTime())) {
					itemBuilder.setReserTime(obj.getReserTime());
				}
				if (!StringUtils.isEmpty(obj.getReserYn())) {
					itemBuilder.setReserYn(obj.getReserYn());
				}
				if (!StringUtils.isEmpty(obj.getActYn())) {
					itemBuilder.setActYn(obj.getActYn());
				}
				if (!StringUtils.isEmpty(obj.getOrderDate())) {
					itemBuilder.setOrderDate(obj.getOrderDate().toString());
				}
				if (!StringUtils.isEmpty(obj.getPksch())) {
					itemBuilder.setPksch(obj.getPksch().toString());
				}
				response.addGridReserOrderList(itemBuilder);
			}
		}
		return response.build();
	}

}
