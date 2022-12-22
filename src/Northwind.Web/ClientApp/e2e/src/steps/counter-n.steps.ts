// Import the cucumber operators we need
import { Before, Given, Then, When } from "@cucumber/cucumber";
import { AppPage } from "../app.po";
import { element, by } from "protractor";
import { expect } from "chai";
let page: AppPage;

Before(() => {
  page = new AppPage();
});

Given("I am on the counter-n page", async () => {
  await page.navigateToCounterN();
});

When("I enter {int} into the user input", async (x: number) => {

  const input = element(by.id("user-input"));

  input.getText.apply(x);

});

When("I click on the increment button", async () => {

  const button = element(by.id("increment-n"));

  await button.click();
});


Then("The counter n should show {string}", async (y: string) => {
  expect(await element(by.id("counter-n")).getText()).to.equal(y);
});
