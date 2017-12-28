package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.ocso.OcsoOCS1003Q05ScheduleItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsoOCS1003Q05ScheduleHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003Q05ScheduleRequest, OcsoServiceProto.OcsoOCS1003Q05ScheduleResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003Q05ScheduleHandler.class);

	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003Q05ScheduleResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003Q05ScheduleRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003Q05ScheduleResponse.Builder response = OcsoServiceProto.OcsoOCS1003Q05ScheduleResponse.newBuilder();
		List<OcsoOCS1003Q05ScheduleItemInfo > listObject = out1001Repository.getOcsoOCS1003Q05Schedule(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getInputGubun(),
				request.getTelYn(), request.getInputTab(), request.getIoGubun(), request.getSelectedInputTab(), request.getBunho(), request.getKijun(),
				request.getNaewonDate(), request.getGwa());
		if (!CollectionUtils.isEmpty(listObject)) {
			for (OcsoOCS1003Q05ScheduleItemInfo  obj : listObject) {
				OcsoModelProto.OcsoOCS1003Q05ScheduleItemInfo .Builder itemBuilder = OcsoModelProto.OcsoOCS1003Q05ScheduleItemInfo .newBuilder();
				if (obj.getNaewonDate() != null) {
					itemBuilder.setNaewonDate(obj.getNaewonDate().toString());
				}
				if (!StringUtils.isEmpty(obj.getGwa())) {
					itemBuilder.setGwa(obj.getGwa());
				}
				if (!StringUtils.isEmpty(obj.getGwaName())) {
					itemBuilder.setGwaName(obj.getGwaName());
				}
				if (!StringUtils.isEmpty(obj.getDoctorName())) {
					itemBuilder.setDoctorName(obj.getDoctorName());
				}
				if (obj.getNalsu() != null) {
					itemBuilder.setNalsu(obj.getNalsu().toString());
				}
				if (!StringUtils.isEmpty(obj.getBunho())) {
					itemBuilder.setBunho(obj.getBunho());
				}
				if (!StringUtils.isEmpty(obj.getDoctor())) {
					itemBuilder.setDoctor(obj.getDoctor());
				}
				if (!StringUtils.isEmpty(obj.getGubunName())) {
					itemBuilder.setGubunName(obj.getGubunName());
				}
				if (!StringUtils.isEmpty(obj.getChojaeName())) {
					itemBuilder.setChojaeName(obj.getChojaeName());
				}
				if (!StringUtils.isEmpty(obj.getNaewonType())) {
					itemBuilder.setNaewonType(obj.getNaewonType());
				}
				if (obj.getJubsuNo() != null) {
					itemBuilder.setJubsuNo(obj.getJubsuNo().toString());
				}
				if (obj.getPkOrder() != null) {
					itemBuilder.setPkOrder(obj.getPkOrder().toString());
				}
				if (!StringUtils.isEmpty(obj.getInputGubun())) {
					itemBuilder.setInputGubun(obj.getInputGubun());
				}
				if (!StringUtils.isEmpty(obj.getTelYn())) {
					itemBuilder.setTelYn(obj.getTelYn());
				}
				if (!StringUtils.isEmpty(obj.getToiwonDrg())) {
					itemBuilder.setToiwonDrg(obj.getToiwonDrg());
				}
				if (!StringUtils.isEmpty(obj.getInputTab())) {
					itemBuilder.setInputTab(obj.getInputTab());
				}
				if (!StringUtils.isEmpty(obj.getIoGubun())) {
					itemBuilder.setIoGubun(obj.getIoGubun());
				}
				if (!StringUtils.isEmpty(obj.getOcsCnt())) {
					itemBuilder.setOcsCnt(obj.getOcsCnt());
				}
				response.addScheduleItem(itemBuilder);
			}
		}
		return response.build();
	}
}
