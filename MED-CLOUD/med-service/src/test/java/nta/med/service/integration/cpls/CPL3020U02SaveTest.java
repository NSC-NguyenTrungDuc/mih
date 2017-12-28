package nta.med.service.integration.cpls;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.integration.MessageRequestTest;

/**
 * @author
 */
public class CPL3020U02SaveTest extends MessageRequestTest {
	@Test
	public void testCPL3020U02Save() throws InterruptedException {

		CplsModelProto.CPL3020U00GrdResultListItemInfo.Builder item = CplsModelProto.CPL3020U00GrdResultListItemInfo
				.newBuilder();
		item.setPkcpl3020("328.0");
		item.setGumsaName("\343\202\257\343\203\254\343\202\242\343\203\201\343\203\213\343\203\263 [\350\241\200\346\270\205]");
		item.setCplResult("(3+)");
		item.setDanuiName("\357\274\255\357\274\247\357\274\217\357\274\244\357\274\254");
		item.setFkocs("4940.0");
		item.setFkcpl2010("63.0");
		item.setLabNo("0303040002");
		item.setHangmogCode("9003200");
		item.setSpecimenCode("03");
		item.setEmergency("N");
		item.setGumsaja("K01CPL");
		item.setSpecimenSer("16030400002");
		item.setSourceGumsa("9003200");
		item.setGroupGubun("02");
		item.setGroupHangmog("9003200");
		item.setDisplayYn("Y");
		item.setDataRowState("Modified");

		CplsServiceProto.CPL3020U02SaveRequest request = CplsServiceProto.CPL3020U02SaveRequest.newBuilder()
				.addGrdResultItemInfo(item).setUserId("10316").setGumsaja("K01CPL").build();

		sentRequestToMedApp(request, CplsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
