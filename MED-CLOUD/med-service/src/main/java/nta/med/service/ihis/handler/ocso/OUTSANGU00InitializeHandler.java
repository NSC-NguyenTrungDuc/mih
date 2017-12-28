package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.ocso.OUTSANGU00InitializeListItemInfo;
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
public class OUTSANGU00InitializeHandler extends ScreenHandler<OcsoServiceProto.OUTSANGU00InitializeRequest, OcsoServiceProto.OUTSANGU00InitializeResponse> {
	private static final Log LOGGER = LogFactory.getLog(OUTSANGU00InitializeHandler.class);

	@Resource
	private OutsangRepository outsangRepository;

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OUTSANGU00InitializeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OUTSANGU00InitializeRequest request) throws Exception {
		OcsoServiceProto.OUTSANGU00InitializeResponse.Builder response = OcsoServiceProto.OUTSANGU00InitializeResponse.newBuilder();
		List<OUTSANGU00InitializeListItemInfo> listResult = outsangRepository.getOUTSANGU00InitializeListItemInfo(getHospitalCode(vertx, sessionId), request.getBunho()
				, request.getGwa(), request.getIoGubun(), request.getAllSangYn(), request.getGijunDate());
		if(listResult != null && !listResult.isEmpty()){
			for(OUTSANGU00InitializeListItemInfo item  : listResult){
				OcsoModelProto.OUTSANGU00InitializeListItemInfo.Builder info = OcsoModelProto.OUTSANGU00InitializeListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getBunho())) {
					info.setBunho(item.getBunho());
				}
				if (!StringUtils.isEmpty(item.getGwa())) {
					info.setGwa(item.getGwa());
				}
				if (!StringUtils.isEmpty(item.getGwaName())) {
					info.setGwaName(item.getGwaName());
				}
				if (!StringUtils.isEmpty(item.getIoGubun())) {
					info.setIoGubun(item.getIoGubun());
				}
				if (!StringUtils.isEmpty(item.getPkSeq())) {
					info.setPkSeq(CommonUtils.parseString(item.getPkSeq()));
				}
				if (!StringUtils.isEmpty(item.getNaewonDate())) {
					info.setNaewonDate(item.getNaewonDate().toString());
				}
				if (!StringUtils.isEmpty(item.getDoctor())) {
					info.setDoctor(item.getDoctor());
				}
				if (!StringUtils.isEmpty(item.getNaewonType())) {
					info.setNaewonType(item.getNaewonType());
				}
				if (!StringUtils.isEmpty(item.getJubsuNo())) {
					info.setJubsuNo(item.getJubsuNo().toString());
				}
				if (!StringUtils.isEmpty(item.getFkinp1001())) {
					info.setFkinp1001(item.getFkinp1001().toString());
				}
				if (!StringUtils.isEmpty(item.getInputId())) {
					info.setInputId(item.getInputId());
				}
				if (!StringUtils.isEmpty(item.getSangCode())) {
					info.setSangCode(item.getSangCode());
				}
				if (!StringUtils.isEmpty(item.getSangName())) {
					info.setSangName(item.getSangName());
				}
				if (!StringUtils.isEmpty(item.getDisSangName())) {
					info.setDisSangName(item.getDisSangName());
				}
				if (!StringUtils.isEmpty(item.getJuSangYn())) {
					info.setJuSangYn(item.getJuSangYn());
				}
				if (!StringUtils.isEmpty(item.getSangStartDate())) {
					info.setSangStartDate(item.getSangStartDate().toString());
				}
				if (!StringUtils.isEmpty(item.getSangEndDate())) {
					info.setSangEndDate(item.getSangEndDate().toString());
				}
				if (!StringUtils.isEmpty(item.getSangEndSayu())) {
					info.setSangEndSayu(item.getSangEndSayu());
				}
				if (!StringUtils.isEmpty(item.getSangEndSayuName())) {
					info.setSangEndSayuName(item.getSangEndSayuName());
				}
				if (!StringUtils.isEmpty(item.getSer())) {
					info.setSer(item.getSer().toString());
				}
				if (!StringUtils.isEmpty(item.getPreModifier1())) {
					info.setPreModifier1(item.getPreModifier1());
				}
				if (!StringUtils.isEmpty(item.getPreModifier2())) {
					info.setPreModifier2(item.getPreModifier2());
				}
				if (!StringUtils.isEmpty(item.getPreModifier3())) {
					info.setPreModifier3(item.getPreModifier3());
				}
				if (!StringUtils.isEmpty(item.getPreModifier4())) {
					info.setPreModifier4(item.getPreModifier4());
				}
				if (!StringUtils.isEmpty(item.getPreModifier5())) {
					info.setPreModifier5(item.getPreModifier5());
				}
				if (!StringUtils.isEmpty(item.getPreModifier6())) {
					info.setPreModifier6(item.getPreModifier6());
				}
				if (!StringUtils.isEmpty(item.getPreModifier7())) {
					info.setPreModifier7(item.getPreModifier7());
				}
				if (!StringUtils.isEmpty(item.getPreModifier8())) {
					info.setPreModifier8(item.getPreModifier8());
				}
				if (!StringUtils.isEmpty(item.getPreModifier9())) {
					info.setPreModifier9(item.getPreModifier9());
				}
				if (!StringUtils.isEmpty(item.getPreModifier10())) {
					info.setPreModifier10(item.getPreModifier10());
				}
				if (!StringUtils.isEmpty(item.getPreModifierName())) {
					info.setPreModifierName(item.getPreModifierName());
				}
				if (!StringUtils.isEmpty(item.getPostModifier1())) {
					info.setPostModifier1(item.getPostModifier1());
				}
				if (!StringUtils.isEmpty(item.getPostModifier2())) {
					info.setPostModifier2(item.getPostModifier2());
				}
				if (!StringUtils.isEmpty(item.getPostModifier3())) {
					info.setPostModifier3(item.getPostModifier3());
				}
				if (!StringUtils.isEmpty(item.getPostModifier4())) {
					info.setPostModifier4(item.getPostModifier4());
				}
				if (!StringUtils.isEmpty(item.getPostModifier5())) {
					info.setPostModifier5(item.getPostModifier5());
				}
				if (!StringUtils.isEmpty(item.getPostModifier6())) {
					info.setPostModifier6(item.getPostModifier6());
				}
				if (!StringUtils.isEmpty(item.getPostModifier7())) {
					info.setPostModifier7(item.getPostModifier7());
				}
				if (!StringUtils.isEmpty(item.getPostModifier8())) {
					info.setPostModifier8(item.getPostModifier8());
				}
				if (!StringUtils.isEmpty(item.getPostModifier9())) {
					info.setPostModifier9(item.getPostModifier9());
				}
				if (!StringUtils.isEmpty(item.getPostModifier10())) {
					info.setPostModifier10(item.getPostModifier10());
				}
				if (!StringUtils.isEmpty(item.getPostModifierName())) {
					info.setPostModifierName(item.getPostModifierName());
				}
				if (!StringUtils.isEmpty(item.getSangJindanDate())) {
					info.setSangJindanDate(item.getSangJindanDate().toString());
				}
				if (!StringUtils.isEmpty(item.getDataGubun())) {
					info.setDataGubun(item.getDataGubun());
				}
				if (!StringUtils.isEmpty(item.getIfDataSendYn())) {
					info.setIfDataSendYn(item.getIfDataSendYn());
				}
				if (!StringUtils.isEmpty(item.getContKey())) {
					info.setContKey(item.getContKey());
				}
				if (item.getEmrPermission() != null) {
					info.setEmrPermission(String.format("%.0f", item.getEmrPermission()));
				}
				response.addInitInfo(info);
			}
		}
		return response.build();
	}

}
