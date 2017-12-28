package nta.med.service.ihis.handler.ocsa;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.doc.Doc4003;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.doc.Doc4003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class DOC4003U00SaveLayoutHandler
		extends
		ScreenHandler<OcsaServiceProto.DOC4003U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	@Resource
	private Doc4003Repository doc4003Repository;

	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsaServiceProto.DOC4003U00SaveLayoutRequest request)
			throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		for (OcsaModelProto.DOC4003U00GrdDOC4003Info info : request
				.getSaveLayoutItemList()) {
			
			if (DataRowState.ADDED.getValue().equalsIgnoreCase(
					info.getRowState())) {
				
				String maxSeq = doc4003Repository.getMaxSeqByHospCodeAndBunho(
						getHospitalCode(vertx, sessionId), info.getBunho());
				Doc4003 doc4003 = new Doc4003();
				doc4003 = createInfo(info, doc4003, hospCode);
				doc4003.setSeq(CommonUtils.parseDouble(maxSeq));
				doc4003Repository.save(doc4003);
			}
			if (DataRowState.MODIFIED.getValue().equalsIgnoreCase(
					info.getRowState())) {
				List<Doc4003> doc4003List = doc4003Repository.findByHospCodeAndBunhoAndPkdoc4003(
								hospCode,
								info.getBunho(), CommonUtils.parseDouble(info.getPkdoc4003()));
				if (!CollectionUtils.isEmpty(doc4003List)) {
					for(Doc4003 doc4003 : doc4003List){
						doc4003Repository.save(createInfo(info, doc4003, hospCode));
					}
				} else {
					response.setResult(false);
					throw new ExecutionException(response.build());
				}
			}
			if (DataRowState.DELETED.getValue().equalsIgnoreCase(info.getRowState())) {
				List<Doc4003> doc4003List = doc4003Repository.findByHospCodeAndPkdoc4003(hospCode, CommonUtils.parseDouble(info.getPkdoc4003()));
				if (!CollectionUtils.isEmpty(doc4003List)) {
					doc4003Repository.delete(doc4003List);
				} else {
					response.setResult(false);
					throw new ExecutionException(response.build());
				}
			}
			
		}
		response.setResult(true);
		return response.build();
	}

	private Doc4003 createInfo(OcsaModelProto.DOC4003U00GrdDOC4003Info info,
			Doc4003 doc4003, String hospCode) {

		doc4003.setSysDate(new Date());
		doc4003.setSysId(info.getSysId());
		doc4003.setHospCode(hospCode);
		doc4003.setPkdoc4003(CommonUtils.parseDouble(info.getPkdoc4003()));
		doc4003.setCreateDate(DateUtil.toDate(info.getCreateDate(),
				DateUtil.PATTERN_YYMMDD));
		doc4003.setToHospitalInfo(info.getToHospitalInfo());
		doc4003.setToSinryouka(info.getToSinryouka());
		doc4003.setToSinryouka2(info.getToSinryouka2());
		doc4003.setToDoctor(info.getToDoctor());
		doc4003.setToDoctor2(info.getToDoctor2());
		doc4003.setDoctor(info.getDoctor());
		doc4003.setGwa(info.getGwa());
		doc4003.setDoctor(info.getDoctor());
		doc4003.setGwa(info.getGwa());
		doc4003.setSuname(info.getSuname());
		doc4003.setSex(info.getSex());
		doc4003.setZip(info.getZip());
		doc4003.setAddress(info.getAAddress());
		doc4003.setTel(info.getTel());
		doc4003.setBirth(DateUtil.toDate(info.getBirth(),
				DateUtil.PATTERN_YYMMDD));
		doc4003.setJob(info.getJob());
		doc4003.setDisease(info.getDisease());
		doc4003.setCheckupOpinion(info.getCheckupOpinion());
		doc4003.setPrescription(info.getPrescription());
		doc4003.setBunho(info.getBunho());
		return doc4003;

	}

}
