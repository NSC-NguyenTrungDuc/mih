package nta.med.service.integration.cpls;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

public class CPL2010U00SaveLayoutTest extends MessageRequestTest{


	@Test
	public void testCLIS2015U02GrdTrialDrgTest() throws InterruptedException {
				CplsServiceProto.CPL2010U00SaveLayoutRequest request = CplsServiceProto.CPL2010U00SaveLayoutRequest
				.newBuilder()
				//CPL2010U00GrdSpecimenListItemInfo
				.setUserId("CPLK01OCS")
				.setOrderDatePr1("2016/01/04")
				.setBunhoPr1("000001663")
				.setJubsujaPr1("K01")
				.setJubsuFlagPr1("Y")
				.setJubsuTimePr1("1212")
				.setRbxMijubsuChecked(true)
				.setBunho("000001663")
				.setJubsuDate("2016/01/04")
				.setPartJubsuDatePr2("2016/01/04")
				.setPartJubsuTimePr2("1212")
				.setPartJubsujaPr2("K01")
				.setUserIdPr2("K01")
				.setIpAddr("192.168.1.215")
				.build();
		sentRequestToMedApp(request, CplsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
